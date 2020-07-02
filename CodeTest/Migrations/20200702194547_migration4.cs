using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTest.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stats_Wisdom",
                table: "Character",
                newName: "Wisdom");

            migrationBuilder.RenameColumn(
                name: "Stats_Strength",
                table: "Character",
                newName: "Strength");

            migrationBuilder.RenameColumn(
                name: "Stats_Intelligence",
                table: "Character",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "Stats_Dexterity",
                table: "Character",
                newName: "Dexterity");

            migrationBuilder.RenameColumn(
                name: "Stats_Constitution",
                table: "Character",
                newName: "Constitution");

            migrationBuilder.RenameColumn(
                name: "Stats_Charisma",
                table: "Character",
                newName: "Charisma");

            migrationBuilder.AddColumn<int>(
                name: "TemporaryHitPoints",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Defense",
                columns: table => new
                {
                    DefenseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Protection = table.Column<string>(nullable: true),
                    CharacterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defense", x => x.DefenseId);
                    table.ForeignKey(
                        name: "FK_Defense_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffectedObject = table.Column<int>(nullable: true),
                    AffectedValue = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: true),
                    CharacterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defense_CharacterId",
                table: "Defense",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CharacterId",
                table: "Item",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defense");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropColumn(
                name: "TemporaryHitPoints",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "Wisdom",
                table: "Character",
                newName: "Stats_Wisdom");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Character",
                newName: "Stats_Strength");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "Character",
                newName: "Stats_Intelligence");

            migrationBuilder.RenameColumn(
                name: "Dexterity",
                table: "Character",
                newName: "Stats_Dexterity");

            migrationBuilder.RenameColumn(
                name: "Constitution",
                table: "Character",
                newName: "Stats_Constitution");

            migrationBuilder.RenameColumn(
                name: "Charisma",
                table: "Character",
                newName: "Stats_Charisma");
        }
    }
}
