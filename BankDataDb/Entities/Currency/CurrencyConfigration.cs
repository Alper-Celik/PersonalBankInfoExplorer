using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable IDE0130 // it is in folder to put it in same place as seed data and config
namespace BankDataDb.Entities;

public class CurrencyConfigration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        _ = builder.HasData(Currency.GetCurrencies());
    }
}
