using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RemoveDoubleBTWNumberKlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankRekeningNummer",
                table: "Klanten");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankRekeningNummer",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
