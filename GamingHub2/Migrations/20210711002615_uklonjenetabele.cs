using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class uklonjenetabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropTable(
                name: "TipKartice");

            migrationBuilder.DropColumn(
                name: "Otkazano",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Igra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Otkazano",
                table: "Narudzba",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Igra",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "KreditnaKartica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<int>(type: "int", nullable: false),
                    GodinaVazenja = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    MjesecVazenja = table.Column<int>(type: "int", nullable: false),
                    SigurnosniKod = table.Column<int>(type: "int", nullable: false),
                    TipKarticeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_TipKartice_TipKarticeID",
                        column: x => x.TipKarticeID,
                        principalTable: "TipKartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KorisnikId",
                table: "KreditnaKartica",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_TipKarticeID",
                table: "KreditnaKartica",
                column: "TipKarticeID");
        }
    }
}
