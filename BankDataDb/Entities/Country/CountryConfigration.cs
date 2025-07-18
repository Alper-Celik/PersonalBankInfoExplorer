using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable IDE0130 // it is in folder to put it in same place as seed data and config
namespace BankDataDb.Entities;

public class CountryConfigration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        string jsonPath = Path.Combine(assemblyPath, "SeedData", "countries.seed.json"); //from https://github.com/stefangabos/world_countries/blob/3480efd5b52aee45ebc22afa224cc05b70c500df/data/countries/en/countries.json
        List<Country> countries =
            JsonSerializer.Deserialize<List<Country>>(File.ReadAllText(jsonPath))
            ?? throw new UnreachableException("json not found");

        foreach (Country country in countries)
        {
            country.Alpha2Code = country.Alpha2Code.ToUpper(CultureInfo.InvariantCulture);
            country.Alpha3Code = country.Alpha3Code.ToUpper(CultureInfo.InvariantCulture);
        }

        _ = builder.HasData(countries);
    }
}