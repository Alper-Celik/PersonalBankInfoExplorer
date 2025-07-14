using System.ComponentModel.DataAnnotations;

using BankDataDb.Entities;

namespace BankDataDb.Importers;

interface IBankImporter
{
    string[] SupportedFileExtensions();

    Task Import(BankDataContext context, string filePath);
}