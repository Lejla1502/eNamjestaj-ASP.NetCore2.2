using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class twofactorKeyAddToKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwoFactorUniqueKey",
                table: "Korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorUniqueKey",
                table: "Korisnik");
        }
    }
}
