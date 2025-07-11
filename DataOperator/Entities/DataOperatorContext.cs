using Microsoft.EntityFrameworkCore;

namespace DataOperator.Entities;

public class DataOperatorContext : DbContext
{

  public DbSet<Country> Countries { get; set; }
  public DbSet<Currency> Currencies { get; set; }
  public DbSet<Bank> Banks { get; set; }
  public DbSet<Card> Cards { get; set; }
  public DbSet<CardTransaction> cardTransactions { get; set; }

}