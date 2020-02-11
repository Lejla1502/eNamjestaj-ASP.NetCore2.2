using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eNamjestaj.Data.Migrations
{
    public partial class inicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkcijskiKatalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktivan = table.Column<bool>(nullable: false),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkcijskiKatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dostava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAccessed = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipUloge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaProizvoda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kanton",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kanton_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KantonId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opstina_Kanton_KantonId",
                        column: x => x.KantonId,
                        principalTable: "Kanton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    OpstinaId = table.Column<int>(nullable: false),
                    UlogaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Opstina_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloga_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dostavljac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    ZiroRacun = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostavljac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dostavljac_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupac_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    VrstaProizvodaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvod_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proizvod_VrstaProizvoda_VrstaProizvodaId",
                        column: x => x.VrstaProizvodaId,
                        principalTable: "VrstaProizvoda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skladiste_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentar_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktivna = table.Column<bool>(nullable: false),
                    BrojNarudzbe = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    NaCekanju = table.Column<bool>(nullable: false),
                    Otkazano = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    OcjenaBr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocjena_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KatalogStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkcijskiKatalogId = table.Column<int>(nullable: false),
                    PopustProcent = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatalogStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KatalogStavka_AkcijskiKatalog_AkcijskiKatalogId",
                        column: x => x.AkcijskiKatalogId,
                        principalTable: "AkcijskiKatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KatalogStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodSkladiste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodSkladiste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProizvodSkladiste_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodSkladiste_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ulaz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    IznosRacuna = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PDV = table.Column<decimal>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ulaz_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ulaz_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izlaz",
                columns: table => new
                {
                    IzlazId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNarudzbe = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DostavaId = table.Column<int>(nullable: false),
                    IznosBezPDV = table.Column<decimal>(nullable: false),
                    IznosSaPDV = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: true),
                    NarudzbaId = table.Column<int>(nullable: false),
                    PovratNovca = table.Column<bool>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    Zakljucena = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izlaz", x => x.IzlazId);
                    table.ForeignKey(
                        name: "FK_Izlaz_Dostava_DostavaId",
                        column: x => x.DostavaId,
                        principalTable: "Dostava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izlaz_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izlaz_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izlaz_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BojaId = table.Column<int>(nullable: false),
                    CijenaProizvoda = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false),
                    PopustNaCijenu = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    TotalStavke = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Boja_BojaId",
                        column: x => x.BojaId,
                        principalTable: "Boja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RadniNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    DostavljacId = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniNalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadniNalog_Dostavljac_DostavljacId",
                        column: x => x.DostavljacId,
                        principalTable: "Dostavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadniNalog_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UlazStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    UlazId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazStavke_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazStavke_Ulaz_UlazId",
                        column: x => x.UlazId,
                        principalTable: "Ulaz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IzlaziStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    IzlazId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Konacnacijena = table.Column<decimal>(nullable: false),
                    Popust = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzlaziStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzlaziStavka_Izlaz_IzlazId",
                        column: x => x.IzlazId,
                        principalTable: "Izlaz",
                        principalColumn: "IzlazId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzlaziStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostavljac_Email",
                table: "Dostavljac",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dostavljac_KorisnikId",
                table: "Dostavljac",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_DostavaId",
                table: "Izlaz",
                column: "DostavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_KorisnikId",
                table: "Izlaz",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz",
                column: "NarudzbaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_SkladisteId",
                table: "Izlaz",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_IzlaziStavka_IzlazId",
                table: "IzlaziStavka",
                column: "IzlazId");

            migrationBuilder.CreateIndex(
                name: "IX_IzlaziStavka_ProizvodId",
                table: "IzlaziStavka",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Kanton_DrzavaId",
                table: "Kanton",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_KatalogStavka_AkcijskiKatalogId",
                table: "KatalogStavka",
                column: "AkcijskiKatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_KatalogStavka_ProizvodId",
                table: "KatalogStavka",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacId",
                table: "Komentar",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KorisnickoIme",
                table: "Korisnik",
                column: "KorisnickoIme",
                unique: true,
                filter: "[KorisnickoIme] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_OpstinaId",
                table: "Korisnik",
                column: "OpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UlogaId",
                table: "Korisnik",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_Email",
                table: "Kupac",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikId",
                table: "Kupac",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KupacId",
                table: "Narudzba",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_BojaId",
                table: "NarudzbaStavka",
                column: "BojaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_NarudzbaId",
                table: "NarudzbaStavka",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_ProizvodId",
                table: "NarudzbaStavka",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KupacId",
                table: "Ocjena",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_KantonId",
                table: "Opstina",
                column: "KantonId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KorisnikId",
                table: "Proizvod",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_Sifra",
                table: "Proizvod",
                column: "Sifra",
                unique: true,
                filter: "[Sifra] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_VrstaProizvodaId",
                table: "Proizvod",
                column: "VrstaProizvodaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodSkladiste_ProizvodId",
                table: "ProizvodSkladiste",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodSkladiste_SkladisteId",
                table: "ProizvodSkladiste",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_DostavljacId",
                table: "RadniNalog",
                column: "DostavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_NarudzbaId",
                table: "RadniNalog",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Skladiste_KorisnikId",
                table: "Skladiste",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaz_KorisnikId",
                table: "Ulaz",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaz_SkladisteId",
                table: "Ulaz",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazStavke_ProizvodId",
                table: "UlazStavke",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazStavke_UlazId",
                table: "UlazStavke",
                column: "UlazId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzlaziStavka");

            migrationBuilder.DropTable(
                name: "KatalogStavka");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "ProizvodSkladiste");

            migrationBuilder.DropTable(
                name: "RadniNalog");

            migrationBuilder.DropTable(
                name: "UlazStavke");

            migrationBuilder.DropTable(
                name: "Izlaz");

            migrationBuilder.DropTable(
                name: "AkcijskiKatalog");

            migrationBuilder.DropTable(
                name: "Boja");

            migrationBuilder.DropTable(
                name: "Dostavljac");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Ulaz");

            migrationBuilder.DropTable(
                name: "Dostava");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "VrstaProizvoda");

            migrationBuilder.DropTable(
                name: "Skladiste");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Kanton");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
