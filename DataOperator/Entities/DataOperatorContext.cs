using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DataOperator.Entities;

public class DataOperatorContext : DbContext
{

  private readonly string? connectionString;

  public DataOperatorContext(DbContextOptions<DataOperatorContext> options) : base(options) { }
  public DataOperatorContext(string _connectionString)
  {
    this.connectionString = _connectionString;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (connectionString is not null)
    {
      optionsBuilder.UseSqlite(connectionString);
    }
    optionsBuilder.UseSeeding((context, _) => SeedCountries(context));
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

  public DbSet<Country> Countries { get; set; }
  public DbSet<Currency> Currencies { get; set; }
  public DbSet<Bank> Banks { get; set; }
  public DbSet<Card> Cards { get; set; }
  public DbSet<CardTransaction> cardTransactions { get; set; }

}