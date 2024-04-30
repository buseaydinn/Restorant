using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class kulll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Tedarikciler",
                newName: "FirmaAd");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Tedarikciler",
                newName: "AdSoyad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirmaAd",
                table: "Tedarikciler",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Tedarikciler",
                newName: "Ad");
        }
    }
}
