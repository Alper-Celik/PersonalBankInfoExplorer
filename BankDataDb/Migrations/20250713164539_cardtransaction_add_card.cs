using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDataDb.Migrations
{
    /// <inheritdoc />
    public partial class cardtransaction_add_card : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardTransactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_CardId",
                table: "CardTransactions",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTransactions_Cards_CardId",
                table: "CardTransactions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardTransactions_Cards_CardId",
                table: "CardTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CardTransactions_CardId",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardTransactions");
        }
    }
}