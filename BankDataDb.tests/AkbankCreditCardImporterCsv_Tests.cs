using Xunit;
using BankDataDb.Importers;

namespace BankDataDb.tests;

public class AkbankCreditCardImporterCsv_Tests
{
  [Theory]
  [InlineData("Some Axes Card : 1234", "Kart Türü / No:;Some Axes Card / **** **** **** 1234;")]
  [InlineData("Some Other Card : 4321", "Kart Türü / No:;Some Other Card / **** **** **** 4321;")]
  public void GetCardName_SholdReturnCorrectData(string expected, string data)
  {
    var importer = new AkbankCreditCardImporterCsv();

    string actual = importer.GetCardName(data);

    Assert.Equal(expected, actual);
  }
}