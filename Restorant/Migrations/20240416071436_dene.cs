using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class dene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Malzemeler_Stoklar_StokId",
                table: "Malzemeler");

            migrationBuilder.DropIndex(
                name: "IX_Malzemeler_StokId",
                table: "Malzemeler");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Malzemeler",
                newName: "Tür");

            migrationBuilder.AlterColumn<string>(
                name: "StokId",
                table: "Malzemeler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Fiyat",
                table: "Malzemeler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "StokId1",
                table: "Malzemeler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_StokId1",
                table: "Malzemeler",
                column: "StokId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Malzemeler_Stoklar_StokId1",
                table: "Malzemeler",
                column: "StokId1",
                principalTable: "Stoklar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Malzemeler_Stoklar_StokId1",
                table: "Malzemeler");

            migrationBuilder.DropIndex(
                name: "IX_Malzemeler_StokId1",
                table: "Malzemeler");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Malzemeler");

            migrationBuilder.DropColumn(
                name: "StokId1",
                table: "Malzemeler");

            migrationBuilder.RenameColumn(
                name: "Tür",
                table: "Malzemeler",
                newName: "Durum");

            migrationBuilder.AlterColumn<int>(
                name: "StokId",
                table: "Malzemeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_StokId",
                table: "Malzemeler",
                column: "StokId");

            migrationBuilder.AddForeignKey(
                name: "FK_Malzemeler_Stoklar_StokId",
                table: "Malzemeler",
                column: "StokId",
                principalTable: "Stoklar",
                principalColumn: "Id");
        }
    }
}
