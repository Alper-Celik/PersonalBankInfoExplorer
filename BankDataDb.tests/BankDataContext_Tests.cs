using System.Threading.Tasks;
using BankDataDb.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.tests;

public class BankDataContext_Tests
{
    [Theory]
    [InlineData("TR", "TUR", "Türkiye")]
    [InlineData("GB", "GBR", "United Kingdom of Great Britain and Northern Ireland")]
    [InlineData("DE", "DEU", "Germany")]
    [InlineData("US", "USA", "United States of America")]
    public async Task BankDataContext_CountrySeeding(string alpha2, string alpha3, string name)
    {
        var context = new BankDataContext();

        await context.Database.MigrateAsync();

        Country country = await context.Countries.Where(c => c.Alpha3Code == alpha3).SingleAsync();
        Assert.Equal(alpha2, country.Alpha2Code);
        Assert.Equal(alpha3, country.Alpha3Code);
        Assert.Equal(name, country.EnglishName);
    }
}
