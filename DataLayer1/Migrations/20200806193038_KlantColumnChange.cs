using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class KlantColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AankomstAdres",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "OphaalAdres",
                table: "Klanten");

            migrationBuilder.AddColumn<string>(
                name: "WoonAdres",
                table: "Klanten",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WoonAdres",
                table: "Klanten");

            migrationBuilder.AddColumn<string>(
                name: "AankomstAdres",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OphaalAdres",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
