using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataDb.Entities;

[Table("Cards")]
public class Card
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [Column(TypeName = "varchar(50)")]
    public CardTypes CardType { get; set; }

    [ForeignKey(nameof(Bank))]
    public int BankId { get; set; }

    public Bank IssuedBank { get; set; } = null!;

}

public enum CardTypes
{
    CreditCard,
    DebitCard,
    PrePaidCard
}