using System.Threading.Tasks;
using BankDataDb.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.tests;

public class BankDataContext_Tests
{
    [Theory]
    [InlineData("tr", "tur", "Türkiye")]
    [InlineData("gb", "gbr", "United Kingdom of Great Britain and Northern Ireland")]
    [InlineData("de", "deu", "Germany")]
    [InlineData("us", "usa", "United States of America")]
    public async Task BankDataContext_CountrySeeding(string alpha2, string alpha3, string name)
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var context = new BankDataContext(connection);

        await context.Database.EnsureCreatedAsync();

        Country country = await context.Countries.Where(c => c.Alpha3Code == alpha3).SingleAsync();
        Assert.Equal(alpha2, country.Alpha2Code);
        Assert.Equal(alpha3, country.Alpha3Code);
        Assert.Equal(name, country.EnglishName);
    }
}
