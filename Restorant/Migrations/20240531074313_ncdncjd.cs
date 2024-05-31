using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class ncdncjd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropColumn(
                name: "OdemeDurum",
                table: "Siparisler");

            migrationBuilder.AddColumn<string>(
                name: "Detay",
                table: "SiparisUrunler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Fiyat",
                table: "SiparisUrunler",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "YorumId",
                table: "SiparisUrunler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detay",
                table: "SiparisMenuler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Fiyat",
                table: "SiparisMenuler",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "YorumId",
                table: "SiparisMenuler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gorunurluk",
                table: "Siparisler",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurumId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kullanıcı",
                table: "Siparisler",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MasaId",
                table: "Siparisler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Sepetler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SiparisDurumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    DurumId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDurumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisDurumlar_Durumlar_DurumId",
                        column: x => x.DurumId,
                        principalTable: "Durumlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDurumlar_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrunler_YorumId",
                table: "SiparisUrunler",
                column: "YorumId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MasaId",
                table: "Siparisler",
                column: "MasaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDurumlar_DurumId",
                table: "SiparisDurumlar",
                column: "DurumId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDurumlar_SiparisId",
                table: "SiparisDurumlar",
                column: "SiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Masalar_MasaId",
                table: "Siparisler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrunler_Yorumlar_YorumId",
                table: "SiparisUrunler",
                column: "YorumId",
                principalTable: "Yorumlar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Masalar_MasaId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrunler_Yorumlar_YorumId",
                table: "SiparisUrunler");

            migrationBuilder.DropTable(
                name: "SiparisDurumlar");

            migrationBuilder.DropIndex(
                name: "IX_SiparisUrunler_YorumId",
                table: "SiparisUrunler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_MasaId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Detay",
                table: "SiparisUrunler");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "SiparisUrunler");

            migrationBuilder.DropColumn(
                name: "YorumId",
                table: "SiparisUrunler");

            migrationBuilder.DropColumn(
                name: "Detay",
                table: "SiparisMenuler");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "SiparisMenuler");

            migrationBuilder.DropColumn(
                name: "YorumId",
                table: "SiparisMenuler");

            migrationBuilder.DropColumn(
                name: "DurumId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Kullanıcı",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "MasaId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Sepetler");

            migrationBuilder.AlterColumn<bool>(
                name: "Gorunurluk",
                table: "Siparisler",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddColumn<string>(
                name: "OdemeDurum",
                table: "Siparisler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    Tur = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odeme_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_SiparisId",
                table: "Odeme",
                column: "SiparisId");
        }
    }
}
