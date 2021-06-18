using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Igra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Izdavac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumIzlaska = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlikaLink = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Konzola",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Detalji = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konzola", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipKartice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKartice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IgraKonzola",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgraID = table.Column<int>(type: "int", nullable: false),
                    KonzolaID = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgraKonzola", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Igra_IgraID",
                        column: x => x.IgraID,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Konzola_KonzolaID",
                        column: x => x.KonzolaID,
                        principalTable: "Konzola",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Adresa2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    DrzavaID = table.Column<int>(type: "int", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kupac_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupac_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    IgraId = table.Column<int>(type: "int", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", maxLength: 20000, nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    VideoRecenzija = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Igra_IgraId",
                        column: x => x.IgraId,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Recenzija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KreditnaKartica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKarticeID = table.Column<int>(type: "int", nullable: false),
                    BrojKartice = table.Column<int>(type: "int", nullable: false),
                    MjesecVazenja = table.Column<int>(type: "int", nullable: false),
                    GodinaVazenja = table.Column<int>(type: "int", nullable: false),
                    SigurnosniKod = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_TipKartice_TipKarticeID",
                        column: x => x.TipKarticeID,
                        principalTable: "TipKartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Uloga_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IgraZanr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgraID = table.Column<int>(type: "int", nullable: false),
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgraZanr", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IgraZanr_Igra_IgraID",
                        column: x => x.IgraID,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IgraZanr_Zanr_ZanrID",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProdajnaCijena = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Popust = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    IgraKonzolaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvod_IgraKonzola_IgraKonzolaID",
                        column: x => x.IgraKonzolaID,
                        principalTable: "IgraKonzola",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IgraKonzola_IgraID",
                table: "IgraKonzola",
                column: "IgraID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraKonzola_KonzolaID",
                table: "IgraKonzola",
                column: "KonzolaID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraZanr_IgraID",
                table: "IgraZanr",
                column: "IgraID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraZanr_ZanrID",
                table: "IgraZanr",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikId",
                table: "KorisnikUloga",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KorisnikId",
                table: "KreditnaKartica",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_TipKarticeID",
                table: "KreditnaKartica",
                column: "TipKarticeID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_DrzavaID",
                table: "Kupac",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikId",
                table: "Kupac",
                column: "KorisnikId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_IgraKonzolaID",
                table: "Proizvod",
                column: "IgraKonzolaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_IgraId",
                table: "Recenzija",
                column: "IgraId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KorisnikId",
                table: "Recenzija",
                column: "KorisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IgraZanr");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "TipKartice");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "IgraKonzola");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Igra");

            migrationBuilder.DropTable(
                name: "Konzola");
        }
    }
}
