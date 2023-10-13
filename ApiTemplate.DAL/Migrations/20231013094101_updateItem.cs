using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextualRPG.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Items_ItemId",
                table: "CharacterItem");

            migrationBuilder.DropColumn(
                name: "SaleValue",
                table: "CharacterItem");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CharacterItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Items_ItemId",
                table: "CharacterItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Items_ItemId",
                table: "CharacterItem");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CharacterItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SaleValue",
                table: "CharacterItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Items_ItemId",
                table: "CharacterItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
