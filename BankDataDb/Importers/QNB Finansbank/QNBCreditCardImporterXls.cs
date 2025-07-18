using System.Globalization;
using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace BankDataDb.Importers.QNB;

// we want to avoid contuning in another thread since DbContext is not thread safe
#pragma warning disable CA2007
public class QNBCreditCardImporterXls : IBankImporter
{
    public Task<(IList<CardTransaction>, IDbContextTransaction)> Import(
        BankDataContext context,
        FileInfo filePath
    )
    {
        FileStream reader = filePath.OpenRead();
        using HSSFWorkbook cardStatementFile = new(reader);

        return Import(context, cardStatementFile);
    }

    public string[] SupportedFileExtensions()
    {
        return ["*.xls"];
    }

    public static async Task<(IList<CardTransaction>, IDbContextTransaction)> Import(
        BankDataContext context,
        HSSFWorkbook cardStatementFile
    )
    {
        ISheet cardStatement = cardStatementFile.GetSheetAt(0);

        string cardInfo = cardStatement.GetRow(5 - 1).GetCell(3 - 1).StringCellValue;
        IDbContextTransaction dbTransaction = await context.Database.BeginTransactionAsync();

        try
        {
            IList<string[]> transactionRows = GetCardTransactionRows(cardStatement);
            Bank qnb = await GetQnbBankAsync(context);
            Card qnbCard = await GetQnbCardAsync(cardInfo, qnb, context);
            IList<CardTransaction> cardTransactions = GetCardTransactions(transactionRows, qnbCard);

            await context.AddRangeAsync(cardTransactions);
            _ = await context.SaveChangesAsync();

            return (cardTransactions, dbTransaction);
        }
        catch (Exception)
        {
            await dbTransaction.RollbackAsync();
            dbTransaction.Dispose();
            throw;
        }

        throw new NotImplementedException();
    }

    public static async Task<Bank> GetQnbBankAsync(BankDataContext context)
    {
        Bank? qnb = context.Banks.FirstOrDefault(static b => b.Name == "QNB Finansbank");
        if (qnb is null)
        {
            qnb = new Bank() { Name = "QNB Finansbank" };
            _ = await context.AddAsync(qnb);
            _ = await context.SaveChangesAsync();
        }
        return qnb;
    }

    public static async Task<Card> GetQnbCardAsync(
        string cardInfo,
        Bank qnb,
        BankDataContext context
    )
    {
        string cardName = GetCardName(cardInfo);
        int cardLast4Digits = GetCardLast4Digits(cardInfo);
        Card? qnbCard = context.Cards.FirstOrDefault(c => c.Id == cardLast4Digits);
        if (qnbCard is null)
        {
            qnbCard = new Card()
            {
                Id = cardLast4Digits,
                Name = cardName,
                IssuedBank = qnb,
            };
            _ = await context.Cards.AddAsync(qnbCard);
            _ = await context.SaveChangesAsync();
        }
        return qnbCard;
    }

    public static IList<CardTransaction> GetCardTransactions(
        IEnumerable<string[]> statementRows,
        Card qnbCard
    )
    {
        List<CardTransaction> cardTransactions = [];

        foreach (string[] row in statementRows)
        {
            // sample date "16/06/2025"
            // so it is dd/mm/yyyy
            int[] dateParts =
            [
                .. row[0]
                    .Split("/")
                    .Select(static s => int.Parse(s, CultureInfo.InvariantCulture.NumberFormat)),
            ];
            DateOnly transactionDate = new(dateParts[2], dateParts[1], dateParts[0]);

            string comment = row[1];

            Currency currency =
                Currency.GetCurrency(
                    string.Concat(row[2].Reverse().TakeWhile(static c => c != ' ').Reverse())
                ) ?? throw new InvalidDataException();

            long amountInMinorUnit = long.Parse(
                string.Concat(
                    row[2]
                        .Reverse()
                        .SkipWhile(static c => c != ' ')
                        .Reverse()
                        .Where(static c => c is not '.' and not ',' and not ' ')
                ),
                CultureInfo.InvariantCulture.NumberFormat
            );
            // TODO : add support for reading installments

            cardTransactions.Add(
                new()
                {
                    TransactionDate = transactionDate,
                    Comment = comment,
                    Currency = currency,
                    CurrencyCode = currency.CurrencyCode,
                    AmountInMinorUnit = amountInMinorUnit,
                    Card = qnbCard,
                }
            );
        }
        return cardTransactions;
    }

    public static IList<string[]> GetCardTransactionRows(ISheet cardStatement)
    {
        List<string[]> cardTransactionRows = [];
        for (
            int i = 6 - 1;
            !string.IsNullOrEmpty(cardStatement.GetRow(i).GetCell(2 - 1).StringCellValue);
            i++
        )
        {
            IRow row = cardStatement.GetRow(i);
            string[] cells = new string[5];

            for (int j = 0; j < 4; j++)
            {
                cells[j] = row.GetCell(j + 1).StringCellValue;
            }
            cardTransactionRows.Add(cells);
        }
        return cardTransactionRows;
    }

    public static string GetCardName(string cardInfo)
    {
        return string.Concat(cardInfo.TakeWhile(static c => c != '-').SkipLast(1));
    }

    public static int GetCardLast4Digits(string cardInfo)
    {
        return int.Parse(
            string.Concat(cardInfo.TakeLast(4)),
            CultureInfo.InvariantCulture.NumberFormat
        );
    }
}