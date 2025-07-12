
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;
using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankDataDb.Entities;

public class CountryConfigration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
    var jsonPath = Path.Combine(assemblyPath, "SeedData", "countries.seed.json");//from https://github.com/stefangabos/world_countries/blob/3480efd5b52aee45ebc22afa224cc05b70c500df/data/countries/en/countries.json
    List<Country> countries = JsonSerializer.Deserialize<List<Country>>(File.ReadAllText(jsonPath)) ?? throw new UnreachableException("json not found");

    foreach (var country in countries)
    {
      country.Alpha2Code = country.Alpha2Code.ToUpper(CultureInfo.InvariantCulture);
      country.Alpha3Code = country.Alpha3Code.ToUpper(CultureInfo.InvariantCulture);
    }

    builder.HasData(countries);
  }
}