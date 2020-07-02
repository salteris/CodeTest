using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTest.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stats_Charisma",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Constitution",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Dexterity",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Intelligence",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Strength",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stats_Wisdom",
                table: "Character",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stats_Charisma",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Stats_Constitution",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Stats_Dexterity",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Stats_Intelligence",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Stats_Strength",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Stats_Wisdom",
                table: "Character");
        }
    }
}
