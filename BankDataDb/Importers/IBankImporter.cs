using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankDataDb.Importers;

public interface IBankImporter
{
    string[] SupportedFileExtensions();

    Task<(IList<CardTransaction>, IDbContextTransaction)> Import(
        BankDataContext context,
        FileInfo filePath
    );
}
