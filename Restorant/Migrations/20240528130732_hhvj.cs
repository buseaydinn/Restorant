using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class hhvj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ToplamFiyat",
                table: "Sepetler",
                type: "decimal(65,30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "Sepetler");
        }
    }
}
