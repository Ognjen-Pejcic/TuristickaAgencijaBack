using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Potvrda_Destinacija_DestinacijaId",
                table: "Potvrda");

            migrationBuilder.DropForeignKey(
                name: "FK_Potvrda_Smestaj_SmestajId",
                table: "Potvrda");

            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Smestaj",
                table: "Smestaj");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Potvrda",
                table: "Potvrda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinacija",
                table: "Destinacija");

            migrationBuilder.RenameTable(
                name: "Smestaj",
                newName: "Smestaji");

            migrationBuilder.RenameTable(
                name: "Potvrda",
                newName: "Potvrde");

            migrationBuilder.RenameTable(
                name: "Destinacija",
                newName: "Destinacije");

            migrationBuilder.RenameIndex(
                name: "IX_Potvrda_SmestajId",
                table: "Potvrde",
                newName: "IX_Potvrde_SmestajId");

            migrationBuilder.RenameIndex(
                name: "IX_Potvrda_DestinacijaId",
                table: "Potvrde",
                newName: "IX_Potvrde_DestinacijaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Smestaji",
                table: "Smestaji",
                column: "SmestajId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Potvrde",
                table: "Potvrde",
                column: "BrojPotvrde");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinacije",
                table: "Destinacije",
                column: "DestinacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Potvrde_Destinacije_DestinacijaId",
                table: "Potvrde",
                column: "DestinacijaId",
                principalTable: "Destinacije",
                principalColumn: "DestinacijaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Potvrde_Smestaji_SmestajId",
                table: "Potvrde",
                column: "SmestajId",
                principalTable: "Smestaji",
                principalColumn: "SmestajId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_Potvrde_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                principalTable: "Potvrde",
                principalColumn: "BrojPotvrde",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Potvrde_Destinacije_DestinacijaId",
                table: "Potvrde");

            migrationBuilder.DropForeignKey(
                name: "FK_Potvrde_Smestaji_SmestajId",
                table: "Potvrde");

            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_Potvrde_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Smestaji",
                table: "Smestaji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Potvrde",
                table: "Potvrde");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinacije",
                table: "Destinacije");

            migrationBuilder.RenameTable(
                name: "Smestaji",
                newName: "Smestaj");

            migrationBuilder.RenameTable(
                name: "Potvrde",
                newName: "Potvrda");

            migrationBuilder.RenameTable(
                name: "Destinacije",
                newName: "Destinacija");

            migrationBuilder.RenameIndex(
                name: "IX_Potvrde_SmestajId",
                table: "Potvrda",
                newName: "IX_Potvrda_SmestajId");

            migrationBuilder.RenameIndex(
                name: "IX_Potvrde_DestinacijaId",
                table: "Potvrda",
                newName: "IX_Potvrda_DestinacijaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Smestaj",
                table: "Smestaj",
                column: "SmestajId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Potvrda",
                table: "Potvrda",
                column: "BrojPotvrde");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinacija",
                table: "Destinacija",
                column: "DestinacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Potvrda_Destinacija_DestinacijaId",
                table: "Potvrda",
                column: "DestinacijaId",
                principalTable: "Destinacija",
                principalColumn: "DestinacijaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Potvrda_Smestaj_SmestajId",
                table: "Potvrda",
                column: "SmestajId",
                principalTable: "Smestaj",
                principalColumn: "SmestajId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                principalTable: "Potvrda",
                principalColumn: "BrojPotvrde",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
