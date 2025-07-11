using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DataOperator.Entities;

[Index(nameof(Alpha2Code), IsUnique = true)]
[Index(nameof(Alpha3Code), IsUnique = true)]
[Index(nameof(NumericCode), IsUnique = true)]
[Table("Countries")]
public class Country
{
  [JsonPropertyName("alpha3")]
  [Key]
  public required string Alpha3Code { get; set; }

  [JsonPropertyName("alpha2")]
  public required string Alpha2Code { get; set; }

  [JsonPropertyName("id")]
  public required short NumericCode { get; set; }

  [JsonPropertyName("name")]
  public required string EnglishName { get; set; }

}