using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BankDataDb.Entities;

public class BankDataContext : DbContext
{
    private readonly string? _connectionString;
    private readonly SqliteConnection? _connection;
    private readonly bool? _closeConnection;

    public BankDataContext(DbContextOptions<BankDataContext> options)
        : base(options) { }

    public BankDataContext(SqliteConnection connection, bool closeConnection = false)
    {
        _connection = connection;
        _closeConnection = closeConnection;
    }

    public BankDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public BankDataContext()
        : this(new SqliteConnection("Data Source=:memory:"), true)
    {
        _connection!.Open();
    }

    public override void Dispose()
    {
        GC.SuppressFinalize(this);
        base.Dispose();
        if (_closeConnection is not null && _connection is not null && _closeConnection.Value)
        {
            _connection.Dispose();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_connectionString is not null)
        {
            _ = optionsBuilder.UseSqlite(_connectionString);
        }
        else if (_connection is not null)
        {
            _ = optionsBuilder.UseSqlite(_connection);
        }
        _ = optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Bank> Banks { get; set; } = null!;
    public DbSet<Card> Cards { get; set; } = null!;
    public DbSet<CardTransaction> CardTransactions { get; set; } = null!;
}
