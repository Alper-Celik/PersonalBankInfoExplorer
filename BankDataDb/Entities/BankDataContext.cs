using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BankDataDb.Entities;

public class BankDataContext : DbContext
{

  private readonly string? connectionString;

  public BankDataContext(DbContextOptions<BankDataContext> options) : base(options) { }
  public BankDataContext(string _connectionString)
  {
    this.connectionString = _connectionString;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (connectionString is not null)
    {
      optionsBuilder.UseSqlite(connectionString);
    }
    optionsBuilder.UseSeeding((context, _) => SeedCountries(context))
                  .UseSeeding((context, _) => SeedCurrincies(context));
  }

  private static void SeedCountries(DbContext context)
  {
    var jsonPath = Path.Combine(Assembly.GetExecutingAssembly().Location, "SeedData", "countries.json");//from https://github.com/stefangabos/world_countries/blob/3480efd5b52aee45ebc22afa224cc05b70c500df/data/countries/en/countries.json
    List<Country> countries = JsonSerializer.Deserialize<List<Country>>(File.ReadAllText(jsonPath)) ?? throw new UnreachableException("json not found");

    foreach (var country in countries.Where(x => !context.Set<Country>().Contains(x)))
    {
      context.Set<Country>().Add(country);
    }
    context.SaveChanges();
  }

  private static void SeedCurrincies(DbContext context)
  {
    var jsonPath = Path.Combine(Assembly.GetExecutingAssembly().Location, "SeedData", "Common-Currency.json");//from gist.githubusercontent.com/ksafranski/2973986/raw/5fda5e87189b066e11c1bf80bbfbecb556cf2cc1/Common-Currency.json
    var currencies_objects = JsonSerializer.Deserialize<JsonNode>(File.ReadAllText(jsonPath));

    List<Currency> currencies = [];

    foreach (var currency_obj in currencies_objects?.AsObject() ?? throw new UnreachableException("cant parse currency seed json"))
    {
      currencies.Add(JsonSerializer.Deserialize<Currency>(currency_obj.Value) ?? throw new UnreachableException("cannot parse currency seed json"));
    }

    foreach (var currency in currencies.Where(x => !context.Set<Currency>().Contains(x)))
    {
      context.Set<Currency>().Add(currency);
    }
    context.SaveChanges();
  }



  public DbSet<Country> Countries { get; set; }
  public DbSet<Currency> Currencies { get; set; }
  public DbSet<Bank> Banks { get; set; }
  public DbSet<Card> Cards { get; set; }
  public DbSet<CardTransaction> cardTransactions { get; set; }

}