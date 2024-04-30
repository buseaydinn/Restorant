using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Migrations
{
    /// <inheritdoc />
    public partial class renk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tür",
                table: "Kategoriler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tür",
                table: "Kategoriler");
        }
    }
}
