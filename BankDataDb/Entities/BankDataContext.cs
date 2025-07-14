using System.Reflection;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.Entities;

public class BankDataContext : DbContext
{

    private readonly string? connectionString;
    private readonly SqliteConnection? connection;
    private readonly bool? closeConnection;

    public BankDataContext(DbContextOptions<BankDataContext> options) : base(options) { }
    public BankDataContext(SqliteConnection _connection, bool _closeConnection = false)
    {
        this.connection = _connection;
        this.closeConnection = _closeConnection;
    }
    public BankDataContext(string _connectionString)
    {
        this.connectionString = _connectionString;
    }

    public BankDataContext() : this(new SqliteConnection("Data Source=:memory:"), true)
    {
        connection!.Open();
    }

    public override void Dispose()
    {
        base.Dispose();
        if (closeConnection is not null && connection is not null && closeConnection.Value)
        {
            connection.Dispose();
        }
    }



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

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Bank> Banks { get; set; } = null!;
    public DbSet<Card> Cards { get; set; } = null!;
    public DbSet<CardTransaction> cardTransactions { get; set; } = null!;

}