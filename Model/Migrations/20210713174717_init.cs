using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteli",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivHotela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTekucegRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteli", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategroije = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    JMBG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrPasosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.JMBG);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    SifraRadnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeRadnika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.SifraRadnika);
                });

            migrationBuilder.CreateTable(
                name: "TipoviSmestaja",
                columns: table => new
                {
                    TipSmestajaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaSmestaja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviSmestaja", x => x.TipSmestajaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoviSobe",
                columns: table => new
                {
                    TipSobeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaSobe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviSobe", x => x.TipSobeId);
                });

            migrationBuilder.CreateTable(
                name: "ZahteviKorisnika",
                columns: table => new
                {
                    SifraZahteva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeBoravka = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviKorisnika", x => x.SifraZahteva);
                });

            migrationBuilder.CreateTable(
                name: "ZahteviZaRez",
                columns: table => new
                {
                    SifraZahteva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrSoba = table.Column<int>(type: "int", nullable: false),
                    BrNocenja = table.Column<int>(type: "int", nullable: false),
                    ZahtevKorisnikaId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    RadnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaRez", x => x.SifraZahteva);
                    table.ForeignKey(
                        name: "FK_ZahteviZaRez_Hoteli_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteli",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZahteviZaRez_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "SifraRadnika",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZahteviZaRez_ZahteviKorisnika_ZahtevKorisnikaId",
                        column: x => x.ZahtevKorisnikaId,
                        principalTable: "ZahteviKorisnika",
                        principalColumn: "SifraZahteva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeRHotela",
                columns: table => new
                {
                    StavkaRezervacijeHotelaId = table.Column<int>(type: "int", nullable: false),
                    ZahtevZaRezervisanjeHotelaId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false),
                    TipSmestajaId = table.Column<int>(type: "int", nullable: false),
                    TipSobeId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeRHotela", x => new { x.StavkaRezervacijeHotelaId, x.ZahtevZaRezervisanjeHotelaId });
                    table.ForeignKey(
                        name: "FK_StavkeRHotela_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeRHotela_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "JMBG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeRHotela_TipoviSmestaja_TipSmestajaId",
                        column: x => x.TipSmestajaId,
                        principalTable: "TipoviSmestaja",
                        principalColumn: "TipSmestajaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeRHotela_TipoviSobe_TipSobeId",
                        column: x => x.TipSobeId,
                        principalTable: "TipoviSobe",
                        principalColumn: "TipSobeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeRHotela_ZahteviZaRez_ZahtevZaRezervisanjeHotelaId",
                        column: x => x.ZahtevZaRezervisanjeHotelaId,
                        principalTable: "ZahteviZaRez",
                        principalColumn: "SifraZahteva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRHotela_KategorijaId",
                table: "StavkeRHotela",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRHotela_KorisnikId",
                table: "StavkeRHotela",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRHotela_TipSmestajaId",
                table: "StavkeRHotela",
                column: "TipSmestajaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRHotela_TipSobeId",
                table: "StavkeRHotela",
                column: "TipSobeId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRHotela_ZahtevZaRezervisanjeHotelaId",
                table: "StavkeRHotela",
                column: "ZahtevZaRezervisanjeHotelaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_HotelId",
                table: "ZahteviZaRez",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_RadnikId",
                table: "ZahteviZaRez",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaRez_ZahtevKorisnikaId",
                table: "ZahteviZaRez",
                column: "ZahtevKorisnikaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkeRHotela");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "TipoviSmestaja");

            migrationBuilder.DropTable(
                name: "TipoviSobe");

            migrationBuilder.DropTable(
                name: "ZahteviZaRez");

            migrationBuilder.DropTable(
                name: "Hoteli");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "ZahteviKorisnika");
        }
    }
}
