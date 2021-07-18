using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.AlterColumn<int>(
                name: "PotvrdaId",
                table: "ZahteviZaRez",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                unique: true,
                filter: "[PotvrdaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                principalTable: "Potvrda",
                principalColumn: "BrojPotvrde",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.AlterColumn<int>(
                name: "PotvrdaId",
                table: "ZahteviZaRez",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                principalTable: "Potvrda",
                principalColumn: "BrojPotvrde",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
