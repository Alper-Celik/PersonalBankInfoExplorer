using System.Text;

using BankDataDb.Entities;

namespace BankDataDb.Importers;

public class AkbankCreditCardImporterCsv : IBankImporter
{
    public async Task Import(BankDataContext context, string filePath)
    {
        IEnumerable<string> data = File.ReadLines(
          filePath,
          Encoding.GetEncoding("windows-1254") // windows turkish since akbank seems to encode it in it for some reason
        );

        var cardName = GetCardName(data.First());
    }

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
          Currency.GetCurrency(string.Concat(columns[2].Reverse().TakeWhile(c => c != ' ').Reverse()))
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