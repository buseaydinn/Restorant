using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class tabloduzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Adresler_AdresId",
                table: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Masalar_MasaId",
                table: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Adresler_AdresId",
                table: "Personeller");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_AdresId",
                table: "Personeller");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_AdresId",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_MasaId",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "OdemeTuru",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Tür",
                table: "Malzemeler");

            migrationBuilder.DropColumn(
                name: "Gorunurluk",
                table: "Kampanyalar");

            migrationBuilder.RenameColumn(
                name: "FirmaAd",
                table: "Tedarikciler",
                newName: "Firma");

            migrationBuilder.RenameColumn(
                name: "AlısFiyati",
                table: "StokGirdiler",
                newName: "MalzemeId");

            migrationBuilder.RenameColumn(
                name: "OdenenTutar",
                table: "Masalar",
                newName: "Qr");

            migrationBuilder.AddColumn<int>(
                name: "Durum",
                table: "Yorumlar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Secenek",
                table: "UrunMalzemeler",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Aktif",
                keyValue: null,
                column: "Aktif",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Aktif",
                table: "Urunler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Ad",
                keyValue: null,
                column: "Ad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Urunler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Acıklama",
                keyValue: null,
                column: "Acıklama",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Acıklama",
                table: "Urunler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Gorunurluk",
                table: "Urunler",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tedarikciler",
                keyColumn: "AdSoyad",
                keyValue: null,
                column: "AdSoyad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Tedarikciler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Eposta",
                table: "Tedarikciler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "StokGirdiler",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Miktar",
                table: "StokGirdiler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ad",
                table: "StokGirdiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Gorunurluk",
                table: "StokGirdiler",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SonStok",
                table: "StokGirdiler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Siparisler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Roller",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roller",
                keyColumn: "Ad",
                keyValue: null,
                column: "Ad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Roller",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Ad",
                table: "Ozellikler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Miktar",
                table: "MenuUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fiyat",
                table: "Menuler",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Akitf",
                table: "Menuler",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Ad",
                keyValue: null,
                column: "Ad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Menuler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Aciklama",
                keyValue: null,
                column: "Aciklama",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Menuler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Menuler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "MasaSiparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OdemeTutar",
                table: "MasaSiparisler",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "MasaSiparisler",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "Kod",
                keyValue: null,
                column: "Kod",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "Masalar",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "Masalar",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Malzemeler",
                keyColumn: "Fiyat",
                keyValue: null,
                column: "Fiyat",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Fiyat",
                table: "Malzemeler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Malzemeler",
                keyColumn: "Ad",
                keyValue: null,
                column: "Ad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Malzemeler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Turu",
                table: "Malzemeler",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Zaman",
                table: "Durumlar",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tur = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_StokGirdiler_MalzemeId",
                table: "StokGirdiler",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_AdresId",
                table: "Siparisler",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_KategoriId",
                table: "Menuler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_MasaSiparisler_MusteriId",
                table: "MasaSiparisler",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_SiparisId",
                table: "Odeme",
                column: "SiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaSiparisler_Musteriler_MusteriId",
                table: "MasaSiparisler",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menuler_Kategoriler_KategoriId",
                table: "Menuler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StokGirdiler_Malzemeler_MalzemeId",
                table: "StokGirdiler",
                column: "MalzemeId",
                principalTable: "Malzemeler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasaSiparisler_Musteriler_MusteriId",
                table: "MasaSiparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Menuler_Kategoriler_KategoriId",
                table: "Menuler");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_StokGirdiler_Malzemeler_MalzemeId",
                table: "StokGirdiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_StokGirdiler_MalzemeId",
                table: "StokGirdiler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_AdresId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Menuler_KategoriId",
                table: "Menuler");

            migrationBuilder.DropIndex(
                name: "IX_MasaSiparisler_MusteriId",
                table: "MasaSiparisler");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Yorumlar");

            migrationBuilder.DropColumn(
                name: "Secenek",
                table: "UrunMalzemeler");

            migrationBuilder.DropColumn(
                name: "Gorunurluk",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Eposta",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "StokGirdiler");

            migrationBuilder.DropColumn(
                name: "Gorunurluk",
                table: "StokGirdiler");

            migrationBuilder.DropColumn(
                name: "SonStok",
                table: "StokGirdiler");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Miktar",
                table: "MenuUrunler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "MasaSiparisler");

            migrationBuilder.DropColumn(
                name: "OdemeTutar",
                table: "MasaSiparisler");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "MasaSiparisler");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Masalar");

            migrationBuilder.DropColumn(
                name: "Turu",
                table: "Malzemeler");

            migrationBuilder.RenameColumn(
                name: "Firma",
                table: "Tedarikciler",
                newName: "FirmaAd");

            migrationBuilder.RenameColumn(
                name: "MalzemeId",
                table: "StokGirdiler",
                newName: "AlısFiyati");

            migrationBuilder.RenameColumn(
                name: "Qr",
                table: "Masalar",
                newName: "OdenenTutar");

            migrationBuilder.AlterColumn<string>(
                name: "Aktif",
                table: "Urunler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Urunler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Acıklama",
                table: "Urunler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Tedarikciler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "StokGirdiler",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Miktar",
                table: "StokGirdiler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Siparisler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OdemeTuru",
                table: "Siparisler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Roller",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Roller",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Ozellikler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Musteriler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fiyat",
                table: "Menuler",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<bool>(
                name: "Akitf",
                table: "Menuler",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Menuler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Menuler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "Masalar",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Fiyat",
                table: "Malzemeler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Malzemeler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tür",
                table: "Malzemeler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Gorunurluk",
                table: "Kampanyalar",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Zaman",
                table: "Durumlar",
                type: "time(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_AdresId",
                table: "Personeller",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_AdresId",
                table: "Musteriler",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_MasaId",
                table: "Musteriler",
                column: "MasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Adresler_AdresId",
                table: "Musteriler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Masalar_MasaId",
                table: "Musteriler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Adresler_AdresId",
                table: "Personeller",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");
        }
    }
}
