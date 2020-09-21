using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addLozinkaSaltHash_ToKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LozinkaHash",
                table: "Korisnik",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LozinkaSalt",
                table: "Korisnik",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LozinkaHash",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "LozinkaSalt",
                table: "Korisnik");
        }
    }
}
