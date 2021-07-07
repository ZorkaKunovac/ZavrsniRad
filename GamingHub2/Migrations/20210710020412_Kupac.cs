using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class Kupac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Drzava_DrzavaID",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Kupac_DrzavaID",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "DrzavaID",
                table: "Kupac");

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "Kupac",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "Kupac");

            migrationBuilder.AddColumn<int>(
                name: "DrzavaID",
                table: "Kupac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_DrzavaID",
                table: "Kupac",
                column: "DrzavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Drzava_DrzavaID",
                table: "Kupac",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
