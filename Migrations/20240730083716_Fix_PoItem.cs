using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class Fix_PoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.RenameTable(
                name: "purchase_order_item",
                newName: "purchase_order_items");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order_items",
                table: "purchase_order_items",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_items_item_id",
                table: "purchase_order_items",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_items_item_id",
                table: "purchase_order_items",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_purchase_order_item_id",
                table: "purchase_order_items",
                column: "item_id",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_purchase_order_po_nbr",
                table: "purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_items_item_id",
                table: "purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_purchase_order_item_id",
                table: "purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_purchase_order_po_nbr",
                table: "purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_order_items",
                table: "purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_items_item_id",
                table: "purchase_order_items");

            migrationBuilder.RenameTable(
                name: "purchase_order_items",
                newName: "purchase_order_item");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_items_po_nbr",
                table: "purchase_order_item",
                column: "po_nbr",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
