using Xunit;
using BankDataDb.Importers;

namespace BankDataDb.tests;

public class AkbankCreditCardImporterCsv_Tests
{
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
}