using BankDataDb.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankDataDb.Importers;

interface IBankImporter
{
    string[] SupportedFileExtensions();

    Task<(IList<CardTransaction>, IDbContextTransaction)> Import(
        BankDataContext context,
        FileInfo filePath
    );
}