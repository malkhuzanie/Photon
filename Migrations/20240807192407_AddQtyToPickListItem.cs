using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class AddQtyToPickListItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pick_list_item_pick_lists_pick_list_pl_nbr",
                table: "pick_list_item");

            migrationBuilder.DropIndex(
                name: "ix_pick_list_item_pick_list_pl_nbr",
                table: "pick_list_item");

            migrationBuilder.DropColumn(
                name: "pick_list_pl_nbr",
                table: "pick_list_item");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "pick_list_item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_pick_list_item_pick_lists_pl_nbr",
                table: "pick_list_item",
                column: "pl_nbr",
                principalTable: "pick_lists",
                principalColumn: "pl_nbr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pick_list_item_pick_lists_pl_nbr",
                table: "pick_list_item");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "pick_list_item");

            migrationBuilder.AddColumn<int>(
                name: "pick_list_pl_nbr",
                table: "pick_list_item",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_pick_list_pl_nbr",
                table: "pick_list_item",
                column: "pick_list_pl_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_pick_list_item_pick_lists_pick_list_pl_nbr",
                table: "pick_list_item",
                column: "pick_list_pl_nbr",
                principalTable: "pick_lists",
                principalColumn: "pl_nbr");
        }
    }
}
