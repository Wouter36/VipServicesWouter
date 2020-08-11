using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Reservaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AankomstPlaats = table.Column<string>(nullable: true),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Startmoment = table.Column<DateTime>(nullable: false),
                    Duur = table.Column<TimeSpan>(nullable: false),
                    limosineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservaties_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservaties_Limosines_limosineId",
                        column: x => x.limosineId,
                        principalTable: "Limosines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservaties_KlantId",
                table: "Reservaties",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaties_limosineId",
                table: "Reservaties",
                column: "limosineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservaties");

            migrationBuilder.CreateTable(
                name: "AirportReservaties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankomstPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    Startmoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VertrekPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limosineId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankomstPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    Startmoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VertrekPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limosineId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankomstPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    Startmoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VertrekPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limosineId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankomstPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    Startmoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VertrekPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limosineId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankomstPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    Startmoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VertrekPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limosineId = table.Column<int>(type: "int", nullable: true)
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
    }
}
