using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingHub2.Migrations
{
    public partial class promjenauIgraKonzolaIgraZanr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "IgraKonzola");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIzmjene",
                table: "IgraZanr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIzmjene",
                table: "IgraKonzola",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumIzmjene",
                table: "IgraZanr");

            migrationBuilder.DropColumn(
                name: "DatumIzmjene",
                table: "IgraKonzola");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "IgraKonzola",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
