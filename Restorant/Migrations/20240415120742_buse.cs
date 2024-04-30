using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class buse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temizlik",
                table: "Masalar");

            migrationBuilder.AlterColumn<decimal>(
                name: "IndirimliFiyat",
                table: "Urunler",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "IndirimTarihi",
                table: "Urunler",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndirimYuzdesi",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IndirimliFiyat",
                table: "Menuler",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "IndirimTarihi",
                table: "Menuler",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndirimYuzdesi",
                table: "Menuler",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndirimTarihi",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "IndirimYuzdesi",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "IndirimTarihi",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "IndirimYuzdesi",
                table: "Menuler");

            migrationBuilder.AlterColumn<int>(
                name: "IndirimliFiyat",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IndirimliFiyat",
                table: "Menuler",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temizlik",
                table: "Masalar",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
