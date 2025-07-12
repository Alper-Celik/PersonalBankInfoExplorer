using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BankDataDb.Entities;

public class BankDataContext : DbContext
{

  private readonly string? connectionString;
  private readonly SqliteConnection? connection;

  public BankDataContext(DbContextOptions<BankDataContext> options) : base(options) { }
  public BankDataContext(SqliteConnection _connection)
  {
    this.connection = _connection;
  }
  public BankDataContext(string _connectionString)
  {
    this.connectionString = _connectionString;
  }

  public BankDataContext() : this("Data Source=:memory:") { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (connectionString is not null)
    {
      optionsBuilder.UseSqlite(connectionString);
    }
    else if (connection is not null)
    {
      optionsBuilder.UseSqlite(connection);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public DbSet<Country> Countries { get; set; }
  public DbSet<Currency> Currencies { get; set; }
  public DbSet<Bank> Banks { get; set; }
  public DbSet<Card> Cards { get; set; }
  public DbSet<CardTransaction> cardTransactions { get; set; }

}