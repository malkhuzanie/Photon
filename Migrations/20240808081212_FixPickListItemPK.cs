using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class FixPickListItemPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_pick_list_item",
                table: "pick_list_item");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pick_list_item",
                table: "pick_list_item",
                columns: new[] { "pl_nbr", "po_nbr", "item_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_pick_list_item",
                table: "pick_list_item");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pick_list_item",
                table: "pick_list_item",
                columns: new[] { "pl_nbr", "po_nbr" });
        }
    }
}
