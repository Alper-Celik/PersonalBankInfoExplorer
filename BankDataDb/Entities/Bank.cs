using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.Entities;

[Table("Banks")]
[Index(nameof(Name), IsUnique = true)]
public class Bank
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
