using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.Tests;

public class Currency_Tests
{
    [Theory]
    [InlineData("TRY", "Turkish Lira", 2)]
    [InlineData("USD", "US Dollar", 2)]
    [InlineData("EUR", "Euro", 2)]
    [InlineData("JPY", "Japanese Yen", 0)]
    public async Task CurrencyConfigration_CurrencySeeding(
        string code,
        string name,
        byte minorUnitFractions
    )
    {
        using BankDataContext context = new();

        await context.Database.MigrateAsync(TestContext.Current.CancellationToken);

        Currency currency = await context
            .Currencies.Where(c => c.CurrencyCode == code)
            .SingleAsync(TestContext.Current.CancellationToken);
        Assert.Equal(code, currency.CurrencyCode);
        Assert.Equal(name, currency.Name);
        Assert.Equal(minorUnitFractions, currency.MinorUnitFractions);
    }
}
