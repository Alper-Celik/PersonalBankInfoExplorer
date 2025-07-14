using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataDb.Entities;

[Table("Cards")]
public class Card
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    [Column(TypeName = "varchar(50)")]
    public CardTypes CardType { get; set; }

    [ForeignKey(nameof(Bank))]
    public required int BankId { get; set; }

    public required Bank IssuedBank { get; set; }

}

public enum CardTypes
{
    CreditCard,
    DebitCard,
    PrePaidCard
}