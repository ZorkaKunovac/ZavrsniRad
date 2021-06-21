using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class Promjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UlogaId",
                table: "Uloga",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KorisnikUlogaId",
                table: "KorisnikUloga",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Uloga",
                newName: "UlogaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "KorisnikUloga",
                newName: "KorisnikUlogaId");
        }
    }
}
