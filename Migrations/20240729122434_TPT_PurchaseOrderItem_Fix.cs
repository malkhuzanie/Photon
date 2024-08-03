using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class TPT_PurchaseOrderItem_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_order_details_inbound_purchase_orders_purc",
                table: "inbound_purchase_order_details");

            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_order_details_purchase_order_item_po_nbr",
                table: "inbound_purchase_order_details");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_order_details_outbound_purchase_orders_pu",
                table: "outbound_purchase_order_details");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_order_details_purchase_order_item_po_nbr",
                table: "outbound_purchase_order_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_outbound_purchase_order_details",
                table: "outbound_purchase_order_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inbound_purchase_order_details",
                table: "inbound_purchase_order_details");

            migrationBuilder.RenameTable(
                name: "outbound_purchase_order_details",
                newName: "outbound_purchase_order_items");

            migrationBuilder.RenameTable(
                name: "inbound_purchase_order_details",
                newName: "inbound_purchase_order_items");

            migrationBuilder.RenameIndex(
                name: "ix_outbound_purchase_order_details_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                newName: "ix_outbound_purchase_order_items_purchase_order_po_nbr");

            migrationBuilder.RenameIndex(
                name: "ix_inbound_purchase_order_details_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                newName: "ix_inbound_purchase_order_items_purchase_order_po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items",
                column: "po_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_order_items_inbound_purchase_orders_purcha",
                table: "inbound_purchase_order_items",
                column: "purchase_order_po_nbr",
                principalTable: "inbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_order_items_purchase_order_item_po_nbr",
                table: "inbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order_item",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_order_items_outbound_purchase_orders_purc",
                table: "outbound_purchase_order_items",
                column: "purchase_order_po_nbr",
                principalTable: "outbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_order_items_purchase_order_item_po_nbr",
                table: "outbound_purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order_item",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_order_items_inbound_purchase_orders_purcha",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_order_items_purchase_order_item_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_order_items_outbound_purchase_orders_purc",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_order_items_purchase_order_item_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items");

            migrationBuilder.RenameTable(
                name: "outbound_purchase_order_items",
                newName: "outbound_purchase_order_details");

            migrationBuilder.RenameTable(
                name: "inbound_purchase_order_items",
                newName: "inbound_purchase_order_details");

            migrationBuilder.RenameIndex(
                name: "ix_outbound_purchase_order_items_purchase_order_po_nbr",
                table: "outbound_purchase_order_details",
                newName: "ix_outbound_purchase_order_details_purchase_order_po_nbr");

            migrationBuilder.RenameIndex(
                name: "ix_inbound_purchase_order_items_purchase_order_po_nbr",
                table: "inbound_purchase_order_details",
                newName: "ix_inbound_purchase_order_details_purchase_order_po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_outbound_purchase_order_details",
                table: "outbound_purchase_order_details",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inbound_purchase_order_details",
                table: "inbound_purchase_order_details",
                column: "po_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_order_details_inbound_purchase_orders_purc",
                table: "inbound_purchase_order_details",
                column: "purchase_order_po_nbr",
                principalTable: "inbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_order_details_purchase_order_item_po_nbr",
                table: "inbound_purchase_order_details",
                column: "po_nbr",
                principalTable: "purchase_order_item",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_order_details_outbound_purchase_orders_pu",
                table: "outbound_purchase_order_details",
                column: "purchase_order_po_nbr",
                principalTable: "outbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_order_details_purchase_order_item_po_nbr",
                table: "outbound_purchase_order_details",
                column: "po_nbr",
                principalTable: "purchase_order_item",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
