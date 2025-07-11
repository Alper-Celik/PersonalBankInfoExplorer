using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataOperator.Entities;

[Index(nameof(Alpha2Code), IsUnique = true)]
[Index(nameof(Alpha3Code), IsUnique = true)]
[Index(nameof(NumericCode), IsUnique = true)]
[Table("Countries")]
public class Country
{
  [Key]
  public required string Alpha3Code { get; set; }
  public required string Alpha2Code { get; set; }
  public required short NumericCode { get; set; }

}