using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class NovaKlasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NovaklasaID",
                table: "IgraZanr",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NovaKlasa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovaKlasa", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IgraZanr_NovaklasaID",
                table: "IgraZanr",
                column: "NovaklasaID");

            migrationBuilder.AddForeignKey(
                name: "FK_IgraZanr_NovaKlasa_NovaklasaID",
                table: "IgraZanr",
                column: "NovaklasaID",
                principalTable: "NovaKlasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IgraZanr_NovaKlasa_NovaklasaID",
                table: "IgraZanr");

            migrationBuilder.DropTable(
                name: "NovaKlasa");

            migrationBuilder.DropIndex(
                name: "IX_IgraZanr_NovaklasaID",
                table: "IgraZanr");

            migrationBuilder.DropColumn(
                name: "NovaklasaID",
                table: "IgraZanr");
        }
    }
}
