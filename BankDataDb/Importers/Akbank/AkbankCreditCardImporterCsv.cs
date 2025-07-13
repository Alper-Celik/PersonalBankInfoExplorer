
using System.Text;
using BankDataDb.Entities;

namespace BankDataDb.Importers;

public class AkbankCreditCardImporterCsv : IBankImporter
{
  public async Task Import(BankDataContext context, string filePath)
  {
    IEnumerable<string> data = File.ReadLines(
      filePath,
      Encoding.GetEncoding("windows-1254")// windows turkish since akbank seems to encode it in it for some reason
      );

    var cardName = GetCardName(data.First());

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
