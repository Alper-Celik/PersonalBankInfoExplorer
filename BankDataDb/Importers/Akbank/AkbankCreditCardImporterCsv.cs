using System.Text;
using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankDataDb.Importers;

public class AkbankCreditCardImporterCsv : IBankImporter
{
    public async Task<(IList<CardTransaction>, IDbContextTransaction)> Import(
        BankDataContext context,
        FileInfo filePath
    )
    {
        IEnumerable<string> data = File.ReadLines(
            filePath.FullName,
            Encoding.GetEncoding("windows-1254") // windows-turkish since akbank seems to encode it in it for some reason
        );
        var dbTransaction = await context.Database.BeginTransactionAsync();

        try
        {
            var akbank = await GetAkbankBankAsync(context);
            var cardFromStatement = await GetAkbankCardAsync(data.First(), akbank, context);
            var cardTransactions = GetCardTransactions(
                GetCardTransactionLines(data),
                cardFromStatement,
                context
            );

            await context.cardTransactions.AddRangeAsync(cardTransactions);
            await context.SaveChangesAsync();
            return (cardTransactions, dbTransaction);
        }
        catch (System.Exception)
        {
            dbTransaction.Rollback();
            dbTransaction.Dispose();
            throw;
        }
    }

    public async Task<Bank> GetAkbankBankAsync(BankDataContext context)
    {
        Bank? akbank = context.Banks.FirstOrDefault(b => b.Name == "Akbank");
        if (akbank is null)
        {
            akbank = new Bank() { Name = "Akbank" };
            await context.Banks.AddAsync(akbank);
            await context.SaveChangesAsync();
        }
        return akbank;
    }

    public async Task<Card> GetAkbankCardAsync(
        string cardLine,
        Bank akbank,
        BankDataContext context
    )
    {
        short cardLast4Digits = GetCardLast4Digits(cardLine);
        Card? cardFromStatement = context.Cards.FirstOrDefault(c => c.Id == cardLast4Digits);
        if (cardFromStatement is null)
        {
            cardFromStatement = new()
            {
                Id = cardLast4Digits,
                Name = GetCardName(cardLine),
                IssuedBank = akbank,
            };
            await context.AddAsync(cardFromStatement);
            await context.SaveChangesAsync();
        }

        return cardFromStatement;
    }

    public List<CardTransaction> GetCardTransactions(
        IEnumerable<string> cardTransactionLines,
        Card cardFromStatement,
        BankDataContext context
    )
    {
        List<CardTransaction> cardTransactions = [];
        string cardTransactionCategory = "";
        foreach (var cardTransactionLine in cardTransactionLines)
        {
            CardTransaction? transaction = GetCardTransaction(
                cardTransactionLine,
                cardFromStatement
            );
            // TODO: add transaction category to the model
            if (transaction is null)
            {
                // read category lines ex.:
                // ";      SUPERMARKET;0,00 TL;0 TL / 0;"
                // note: 0TL part is just empty data it doesn't mean all SUPERMARKET transactions costed 0 TL
                cardTransactionCategory = string.Concat(
                    cardTransactionLine.Split(";")[1].SkipWhile(c => c == ' ')
                );
                continue;
            }
            cardTransactions.Add(transaction);
        }
        return cardTransactions;
    }

    public static IEnumerable<string> GetCardTransactionLines(IEnumerable<string> lines) =>
        lines
            .SkipWhile(l => !l.StartsWith("Tarih"))
            .Skip(1) // skip until and the "Tarih;Açıklama;Tutar;Chip Para / Mil;" line
            .TakeWhile(l => l.Contains(";")); // last lines doesn't contain semicolons

    // parses transaction info csv line and returns CardTransaction
    // example csv lines:
    // - "8.07.2025;[Redacted]             [Redacted(city)]         TR;65,00 TL;0 TL / 0;"
    // - "17.06.2025;Chip-Para ile Ödeme;-133,60 TL;-133,60 TL / 0;"
    //
    // returns null if first column is null like in sector columns ex. ";   TURISM AND ENTERTAINMENT;0,00 TL;0 TL / 0;"
    // schema of the line is : Tarih|Açıklama|Tutar|Chip Para / Mil
    public static CardTransaction? GetCardTransaction(string line, Card card)
    {
        var columns = line.Split(";");

        if (columns[0] == string.Empty)
        {
            return null;
        }

        var dateParts = columns[0].Split(".").Select(x => int.Parse(x)).ToArray();
        DateOnly transactionDate = new(day: dateParts[0], month: dateParts[1], year: dateParts[2]);

        string comment = columns[1];

        // if it has country code it is in the last part
        // like in "******    *****       TR"
        Country? country = Country.GetCountry(
            string.Concat(comment.Reverse().TakeWhile(c => c != ' ').Reverse())
        );

        long amountInMinorUnit = long.Parse(
            string.Concat(columns[2].TakeWhile(c => c != ' ').Where(c => c != '.' && c != ','))
        );

        Currency currency =
            Currency.GetCurrency(
                string.Concat(columns[2].Reverse().TakeWhile(c => c != ' ').Reverse())
            )
            ?? new Currency
            {
                CurrencyCode = "TRY",
                Symbol = "TL",
                MinorUnitFractions = 2,
            };

        return new()
        {
            TransactionDate = transactionDate,
            Comment = comment,
            AmountInMinorUnit = amountInMinorUnit,
            CurrencyCode = currency.CurrencyCode,
            Currency = currency,
            Country = country,
            CountryAlpha3Code = country?.Alpha3Code,
            Card = card,
        };
    }

    // gets card name and last 4 digits of card number from
    // first line of csv data
    //
    // example data "Kart Türü / No:;Some Axes Card / **** **** **** 1234;"
    public static string GetCardName(string data)
    {
        var cardNameAndNo = data.Split(";")[1].Split("/");
        var CardName = cardNameAndNo[0];
        CardName = string.Concat(CardName.Take(CardName.Length - 1));
        return CardName;
    }

    public static short GetCardLast4Digits(string data)
    {
        var cardNameAndNo = data.Split(";")[1].Split("/");
        var Last4Digits = string.Concat(cardNameAndNo[1].Skip(16).Take(4));
        return short.Parse(Last4Digits);
    }

    public string[] SupportedFileExtensions()
    {
        return [".csv"];
    }
}