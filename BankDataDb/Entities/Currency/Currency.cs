
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.Entities;

[Index(nameof(CurrencyCode), IsUnique = true)]
[Table("Currencies")]
public class Currency
{
  [JsonPropertyName("code")]
  [Column(TypeName = ("char(3)")), Key]
  public required string CurrencyCode { get; set; }

  [JsonPropertyName("name")]
  public string? Name { get; set; }

  [JsonPropertyName("decimal_digits")]
  public required byte MinorUnitFractions { get; set; } // see : https://en.wikipedia.org/wiki/ISO_4217#Minor_unit_fractions
}