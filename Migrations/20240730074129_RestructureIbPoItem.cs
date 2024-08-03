using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class RestructureIbPoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shipped_quantity",
                table: "purchase_order_item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shipped_quantity",
                table: "outbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shipped_quantity",
                table: "inbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "inbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "outbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "purchase_order_item",
                column: "po_nbr",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropColumn(
                name: "shipped_quantity",
                table: "purchase_order_item");

            migrationBuilder.DropColumn(
                name: "shipped_quantity",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "shipped_quantity",
                table: "inbound_purchase_order_items");
        }
    }
}
