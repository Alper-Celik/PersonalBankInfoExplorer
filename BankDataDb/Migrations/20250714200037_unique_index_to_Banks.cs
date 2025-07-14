using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDataDb.Migrations
{
    /// <inheritdoc />
    public partial class unique_index_to_Banks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Banks_Name",
                table: "Banks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Banks_Name",
                table: "Banks");
        }
    }
}
