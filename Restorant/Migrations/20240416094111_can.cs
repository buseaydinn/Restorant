using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class can : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KategorId",
                table: "Urunler",
                newName: "KategoriId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Roller",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Roller");

            migrationBuilder.RenameColumn(
                name: "KategoriId",
                table: "Urunler",
                newName: "KategorId");
        }
    }
}
