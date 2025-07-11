using System.ComponentModel.DataAnnotations.Schema;

namespace DataOperator.Entities;

[Table("Banks")]
public class Bank
{
  public int Id { get; set; }
  public required string Name { get; set; }
}