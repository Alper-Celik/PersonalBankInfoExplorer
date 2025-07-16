using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.tests;

public class Country_Tests
{
    [Theory]
    [InlineData("TR", "TUR")]
    [InlineData("us", "USA")]
    void GetCountry_SjouldReturnCorrectDataFromAlpha2Code(string alpha2, string alpha3)
    {
        var actual = Country.GetCountry(alpha2)?.Alpha3Code;

        Assert.Equal(alpha3, actual);
    }

    [Theory]
    [InlineData("tur", "TR")]
    [InlineData("USA", "US")]
    void GetCountry_SjouldReturnCorrectDataFromAlpha3Code(string alpha3, string alpha2)
    {
        var actual = Country.GetCountry(alpha3)?.Alpha2Code;

        Assert.Equal(alpha2, actual);
    }

    [Theory]
    [InlineData("TR", "TUR", "Türkiye")]
    [InlineData("GB", "GBR", "United Kingdom of Great Britain and Northern Ireland")]
    [InlineData("DE", "DEU", "Germany")]
    [InlineData("US", "USA", "United States of America")]
    public async Task CountryConfigration_CountrySeeding(string alpha2, string alpha3, string name)
    {
        var context = new BankDataContext();

        await context.Database.MigrateAsync(TestContext.Current.CancellationToken);

        Country country = await context
            .Countries.Where(c => c.Alpha3Code == alpha3)
            .SingleAsync(TestContext.Current.CancellationToken);
        Assert.Equal(alpha2, country.Alpha2Code);
        Assert.Equal(alpha3, country.Alpha3Code);
        Assert.Equal(name, country.EnglishName);
    }
}