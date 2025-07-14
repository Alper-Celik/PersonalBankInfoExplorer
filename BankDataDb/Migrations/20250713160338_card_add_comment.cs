using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDataDb.Migrations
{
    /// <inheritdoc />
    public partial class card_add_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CardTransactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CardTransactions");
        }
    }
}