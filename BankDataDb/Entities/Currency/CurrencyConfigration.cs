using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankDataDb.Entities;


public class CurrencyConfigration : IEntityTypeConfiguration<Currency>
{
  public void Configure(EntityTypeBuilder<Currency> builder)
  {
    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
    var jsonPath = Path.Combine(assemblyPath, "SeedData", "Common-Currency.seed.json");//from gist.githubusercontent.com/ksafranski/2973986/raw/5fda5e87189b066e11c1bf80bbfbecb556cf2cc1/Common-Currency.json
    var currencies_objects = JsonSerializer.Deserialize<JsonNode>(File.ReadAllText(jsonPath));

    List<Currency> currencies = [];

    foreach (var currency_obj in currencies_objects?.AsObject() ?? throw new UnreachableException("cant parse currency seed json"))
    {
      currencies.Add(JsonSerializer.Deserialize<Currency>(currency_obj.Value) ?? throw new UnreachableException("cannot parse currency seed json"));
    }

    builder.HasData(currencies);
  }
}