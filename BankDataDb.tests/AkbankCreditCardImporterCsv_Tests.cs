using BankDataDb.Entities;
using BankDataDb.Importers;

namespace BankDataDb.tests;

// TODO: add tests for import function with in memory sqlite database
public class AkbankCreditCardImporterCsv_Tests
{
    public static IEnumerable<object[]?> GetTransactionLines_ShouldReturnData_Data =>
        new List<object[]?>
        {
            new object[]
            {
                new List<string>
                {
                    "some line;",
                    "some other line ; test;",
                    "Tarih;Açıklama;Tutar;Chip Para / Mil;",
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                    "",
                    "Akbank T.A.Ş.",
                },
                new List<string>
                {
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                    "Redacted.Redacted.2025;Redacted;-1.500,00 TL;0 TL / 0;",
                },
            },
        };

    [Theory]
    [MemberData(nameof(GetTransactionLines_ShouldReturnData_Data))]
    public void GetTransactionLines_ShouldReturnData(
        IEnumerable<string> data,
        IEnumerable<string> expected
    )
    {
        var actual = AkbankCreditCardImporterCsv.GetTransactionLines(data);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> GetCardTransaction_ShouldReturnCorrectData_Data =>
        new List<object?[]>()
        {
            new object?[] { ";   TURISM AND ENTERTAINMENT;0,00 TL;0 TL / 0;", null },
            new object[]
            {
                "8.07.2025;[Redacted]             [Redacted(city)]         TR;65,00 TL;0 TL / 0;",
                new CardTransaction()
                {
                    TransactionDate = new DateOnly(2025, 7, 8),
                    AmountInMinorUnit = 6500,
                    Comment = "[Redacted]             [Redacted(city)]         TR",
                    CurrencyCode = "TRY",
                    CountryAlpha3Code = "TUR",

                    Currency = null!,
                    Card = null!,
                },
            },
            new object[]
            {
                "17.06.2025;Chip-Para ile Ödeme;-133,60 TL;-133,60 TL / 0;",
                new CardTransaction()
                {
                    TransactionDate = new DateOnly(2025, 6, 17),
                    Comment = "Chip-Para ile Ödeme",
                    AmountInMinorUnit = -13360,
                    CurrencyCode = "TRY",
                    CountryAlpha3Code = null,

                    Currency = null!,
                    Card = null!,
                },
            },
        };

    [Theory]
    [MemberData(nameof(GetCardTransaction_ShouldReturnCorrectData_Data))]
    public void GetCardTransaction_ShouldReturnCorrectData(string line, CardTransaction? expected)
    {
        CardTransaction? actual = AkbankCreditCardImporterCsv.GetCardTransaction(line, null!);

        if (expected is null)
        {
            Assert.Null(actual);
            return;
        }

        Assert.Equal(expected.TransactionDate, actual!.TransactionDate);
        Assert.Equal(expected.Comment, actual.Comment);
        Assert.Equal(expected.AmountInMinorUnit, actual.AmountInMinorUnit);
        Assert.Equal(expected.CurrencyCode, actual.CurrencyCode);
        Assert.Equal(expected.CountryAlpha3Code, actual.CountryAlpha3Code);
    }

    [Theory]
    [InlineData("Some Axes Card", "Kart Türü / No:;Some Axes Card / **** **** **** 1234;")]
    [InlineData("Some Other Card", "Kart Türü / No:;Some Other Card / **** **** **** 4321;")]
    public void GetCardName_SholdReturnCorrectData(string expected, string data)
    {
        string actual = AkbankCreditCardImporterCsv.GetCardName(data);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1234, "Kart Türü / No:;Some Axes Card / **** **** **** 1234;")]
    [InlineData(4321, "Kart Türü / No:;Some Other Card / **** **** **** 4321;")]
    public void GetCardLast4Digits_SholdReturnCorrectData(short expected, string data)
    {
        short actual = AkbankCreditCardImporterCsv.GetCardLast4Digits(data);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SupportedFileExtensions_ShouldReturnCorrectData()
    {
        AkbankCreditCardImporterCsv importer = new();
        string[] expected = [".csv"];

        var actual = importer.SupportedFileExtensions();

        Assert.Equal(expected, actual);
    }
}