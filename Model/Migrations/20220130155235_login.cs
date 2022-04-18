using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Radnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Radnici",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Radnici");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Radnici");
        }
    }
}
