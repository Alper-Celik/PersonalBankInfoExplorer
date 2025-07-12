
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataDb.Entities;

[Table("CardTransactions")]
public class CardTransaction
{
  public required int Id { get; set; }
  public required DateOnly TransactionDate { get; set; }
  public TimeOnly? TransactionTime { get; set; }
  public long AmountInMinorUnit { get; set; }

  [ForeignKey(nameof(Currency))]
  public required string CurrencyCode { get; set; }
  public required Currency Currency { get; set; }

  [ForeignKey(nameof(Country))]
  public string? CountryAlpha3Code { get; set; }
  public Country? Country { get; set; }
  // ...

}