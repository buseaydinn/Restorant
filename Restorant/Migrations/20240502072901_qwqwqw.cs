using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class qwqwqw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tedarikciler_Adresler_AdresId",
                table: "Tedarikciler");

            migrationBuilder.DropIndex(
                name: "IX_Tedarikciler_AdresId",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Tedarikciler");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Tedarikciler",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Tedarikciler");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Tedarikciler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tedarikciler_AdresId",
                table: "Tedarikciler",
                column: "AdresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tedarikciler_Adresler_AdresId",
                table: "Tedarikciler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");
        }
    }
}
