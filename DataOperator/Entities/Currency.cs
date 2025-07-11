
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataOperator.Entities;

[Index(nameof(CurrencyCode), IsUnique = true)]
[Index(nameof(CurrencyNumber), IsUnique = true)]
[Table("Currencies")]
public class Currency
{
  [Column(TypeName = ("char(3)")), Key]
  public required string CurrencyCode { get; set; }
  public short? CurrencyNumber { get; set; }
  public string? Name { get; set; }
  public required int MinorUnitFractions { get; set; } // see : https://en.wikipedia.org/wiki/ISO_4217#Minor_unit_fractions
}