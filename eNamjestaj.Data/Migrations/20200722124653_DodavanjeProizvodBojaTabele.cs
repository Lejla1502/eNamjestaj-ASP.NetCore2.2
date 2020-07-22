using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class DodavanjeProizvodBojaTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProizvodBoja",
                columns: table => new
                {
                    BojaId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodBoja", x => new { x.ProizvodId, x.BojaId });
                    table.UniqueConstraint("AK_ProizvodBoja_BojaId_ProizvodId", x => new { x.BojaId, x.ProizvodId });
                    table.ForeignKey(
                        name: "FK_ProizvodBoja_Boja_BojaId",
                        column: x => x.BojaId,
                        principalTable: "Boja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodBoja_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodBoja");
        }
    }
}
