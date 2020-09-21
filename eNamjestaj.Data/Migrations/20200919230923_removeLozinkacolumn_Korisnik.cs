using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class removeLozinkacolumn_Korisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Korisnik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Korisnik",
                nullable: true);
        }
    }
}
