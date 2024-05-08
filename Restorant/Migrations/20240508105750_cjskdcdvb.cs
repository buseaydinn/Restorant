using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class cjskdcdvb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kategori",
                table: "Masalar",
                newName: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Masalar_KategoriId",
                table: "Masalar",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar");

            migrationBuilder.DropIndex(
                name: "IX_Masalar_KategoriId",
                table: "Masalar");

            migrationBuilder.RenameColumn(
                name: "KategoriId",
                table: "Masalar",
                newName: "Kategori");
        }
    }
}
