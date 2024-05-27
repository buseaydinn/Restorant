using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class ksksckdnc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToplamFiyat",
                table: "Urunler",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "Urunler");
        }
    }
}
