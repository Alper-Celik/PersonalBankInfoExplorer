
using System.Diagnostics;
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

    builder.HasData(countries);
  }
}