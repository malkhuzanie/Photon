using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class Fix_PoItem_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "fk_purchase_order_items_item_id",
            //     table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_purchase_order_item_id",
                table: "purchase_order_items");

            // migrationBuilder.DropIndex(
            //     name: "ix_purchase_order_item_id",
            //     table: "purchase_order");

            // migrationBuilder.DropColumn(
            //     name: "item_id",
            //     table: "purchase_order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "item_id",
            //     table: "purchase_order",
            //     type: "integer",
            //     nullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "ix_purchase_order_item_id",
            //     table: "purchase_order",
            //     column: "item_id");

            // migrationBuilder.AddForeignKey(
            //     name: "fk_purchase_order_items_item_id",
            //     table: "purchase_order",
            //     column: "item_id",
            //     principalTable: "items",
            //     principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_purchase_order_item_id",
                table: "purchase_order_items",
                column: "item_id",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
