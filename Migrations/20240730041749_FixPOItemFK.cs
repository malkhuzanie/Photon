using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class FixPOItemFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inbound_purchase_order_items_purchase_order_purchase_order_~",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_outbound_purchase_order_items_purchase_order_purchase_order~",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_item_purchase_order_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.RenameColumn(
                name: "purchase_order_po_nbr",
                table: "purchase_order_item",
                newName: "po_nbr");

            migrationBuilder.RenameColumn(
                name: "purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                newName: "po_nbr");

            migrationBuilder.RenameColumn(
                name: "purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                newName: "po_nbr");

            migrationBuilder.AddForeignKey(
                name: "FK_inbound_purchase_order_items_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_outbound_purchase_order_items_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inbound_purchase_order_items_purchase_order_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_outbound_purchase_order_items_purchase_order_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.RenameColumn(
                name: "po_nbr",
                table: "purchase_order_item",
                newName: "purchase_order_po_nbr");

            migrationBuilder.RenameColumn(
                name: "po_nbr",
                table: "outbound_purchase_order_items",
                newName: "purchase_order_po_nbr");

            migrationBuilder.RenameColumn(
                name: "po_nbr",
                table: "inbound_purchase_order_items",
                newName: "purchase_order_po_nbr");

            migrationBuilder.AddForeignKey(
                name: "FK_inbound_purchase_order_items_purchase_order_purchase_order_~",
                table: "inbound_purchase_order_items",
                column: "purchase_order_po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_outbound_purchase_order_items_purchase_order_purchase_order~",
                table: "outbound_purchase_order_items",
                column: "purchase_order_po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_item_purchase_order_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "purchase_order_po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
