using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_ZahteviKorisnika_ZahtevKorisnikaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaRez_ZahtevKorisnikaId",
                table: "ZahteviZaRez");

            migrationBuilder.AlterColumn<int>(
                name: "ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PotvrdaId",
                table: "ZahteviZaRez",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Destinacija",
                columns: table => new
                {
                    DestinacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDestinacije = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinacija", x => x.DestinacijaId);
                });

            migrationBuilder.CreateTable(
                name: "Smestaj",
                columns: table => new
                {
                    SmestajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSmestaja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smestaj", x => x.SmestajId);
                });

            migrationBuilder.CreateTable(
                name: "Potvrda",
                columns: table => new
                {
                    BrojPotvrde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usluga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmestajId = table.Column<int>(type: "int", nullable: true),
                    DestinacijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potvrda", x => x.BrojPotvrde);
                    table.ForeignKey(
                        name: "FK_Potvrda_Destinacija_DestinacijaId",
                        column: x => x.DestinacijaId,
                        principalTable: "Destinacija",
                        principalColumn: "DestinacijaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Potvrda_Smestaj_SmestajId",
                        column: x => x.SmestajId,
                        principalTable: "Smestaj",
                        principalColumn: "SmestajId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                column: "ZahtevKorisnikaId",
                unique: true,
                filter: "[ZahtevKorisnikaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrda_DestinacijaId",
                table: "Potvrda",
                column: "DestinacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrda_SmestajId",
                table: "Potvrda",
                column: "SmestajId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez",
                column: "PotvrdaId",
                principalTable: "Potvrda",
                principalColumn: "BrojPotvrde",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_ZahteviKorisnika_ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                column: "ZahtevKorisnikaId",
                principalTable: "ZahteviKorisnika",
                principalColumn: "SifraZahteva",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_Potvrda_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaRez_ZahteviKorisnika_ZahtevKorisnikaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropTable(
                name: "Potvrda");

            migrationBuilder.DropTable(
                name: "Destinacija");

            migrationBuilder.DropTable(
                name: "Smestaj");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaRez_PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaRez_ZahtevKorisnikaId",
                table: "ZahteviZaRez");

            migrationBuilder.DropColumn(
                name: "PotvrdaId",
                table: "ZahteviZaRez");

            migrationBuilder.AlterColumn<int>(
                name: "ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                column: "ZahtevKorisnikaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaRez_ZahteviKorisnika_ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                column: "ZahtevKorisnikaId",
                principalTable: "ZahteviKorisnika",
                principalColumn: "SifraZahteva",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
