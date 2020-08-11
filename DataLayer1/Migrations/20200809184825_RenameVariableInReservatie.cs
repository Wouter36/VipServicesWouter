using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RenameVariableInReservatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaties_Limosines_limosineId",
                table: "Reservaties");

            migrationBuilder.RenameColumn(
                name: "limosineId",
                table: "Reservaties",
                newName: "LimosineId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaties_limosineId",
                table: "Reservaties",
                newName: "IX_Reservaties_LimosineId");

            migrationBuilder.AlterColumn<int>(
                name: "LimosineId",
                table: "Reservaties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaties_Limosines_LimosineId",
                table: "Reservaties",
                column: "LimosineId",
                principalTable: "Limosines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaties_Limosines_LimosineId",
                table: "Reservaties");

            migrationBuilder.RenameColumn(
                name: "LimosineId",
                table: "Reservaties",
                newName: "limosineId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaties_LimosineId",
                table: "Reservaties",
                newName: "IX_Reservaties_limosineId");

            migrationBuilder.AlterColumn<int>(
                name: "limosineId",
                table: "Reservaties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaties_Limosines_limosineId",
                table: "Reservaties",
                column: "limosineId",
                principalTable: "Limosines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
