using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class AddItemPickupStatusF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items");

            migrationBuilder.AlterColumn<int>(
                name: "item_pickup_status_id",
                table: "purchase_order_items",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items",
                column: "item_pickup_status_id",
                principalTable: "item_pickup_status",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items");

            migrationBuilder.AlterColumn<int>(
                name: "item_pickup_status_id",
                table: "purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items",
                column: "item_pickup_status_id",
                principalTable: "item_pickup_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
