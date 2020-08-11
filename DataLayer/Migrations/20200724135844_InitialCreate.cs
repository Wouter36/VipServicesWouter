using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantCategorie = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    BTWNummer = table.Column<string>(nullable: true),
                    BankRekeningNummer = table.Column<string>(nullable: true),
                    OphaalAdres = table.Column<string>(nullable: true),
                    AankomstAdres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Limosines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    EersteUurPrijs = table.Column<int>(nullable: false),
                    NightLifePrijs = table.Column<int>(nullable: false),
                    WeddingPrijs = table.Column<int>(nullable: false),
                    WellnessPrijs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limosines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportReservaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportReservaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportReservaties_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportReservaties_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessReservatie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessReservatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessReservatie_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessReservatie_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NightLifeReservaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NightLifeReservaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NightLifeReservaties_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NightLifeReservaties_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeddingReservaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingReservaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeddingReservaties_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingReservaties_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WellnessReservaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellnessReservaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WellnessReservaties_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WellnessReservaties_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportReservaties_KlantId",
                table: "AirportReservaties",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportReservaties_limosineId",
                table: "AirportReservaties",
                column: "limosineId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessReservatie_KlantId",
                table: "BusinessReservatie",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessReservatie_limosineId",
                table: "BusinessReservatie",
                column: "limosineId");

            migrationBuilder.CreateIndex(
                name: "IX_NightLifeReservaties_KlantId",
                table: "NightLifeReservaties",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_NightLifeReservaties_limosineId",
                table: "NightLifeReservaties",
                column: "limosineId");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingReservaties_KlantId",
                table: "WeddingReservaties",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingReservaties_limosineId",
                table: "WeddingReservaties",
                column: "limosineId");

            migrationBuilder.CreateIndex(
                name: "IX_WellnessReservaties_KlantId",
                table: "WellnessReservaties",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_WellnessReservaties_limosineId",
                table: "WellnessReservaties",
                column: "limosineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportReservaties");

            migrationBuilder.DropTable(
                name: "BusinessReservatie");

            migrationBuilder.DropTable(
                name: "NightLifeReservaties");

            migrationBuilder.DropTable(
                name: "WeddingReservaties");

            migrationBuilder.DropTable(
                name: "WellnessReservaties");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Limosines");
        }
    }
}
