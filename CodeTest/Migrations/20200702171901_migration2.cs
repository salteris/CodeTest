using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTest.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHitPoints",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumHitPoints",
                table: "Character",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHitPoints",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "MaximumHitPoints",
                table: "Character");
        }
    }
}
