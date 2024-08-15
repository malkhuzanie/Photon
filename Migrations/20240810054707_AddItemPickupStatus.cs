using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class AddItemPickupStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "item_pickup_status_id",
                table: "purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "item_pickup_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_pickup_status", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_items_item_pickup_status_id",
                table: "purchase_order_items",
                column: "item_pickup_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_po_nbr",
                table: "pick_list_item",
                column: "po_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_pick_list_item_purchase_orders_po_nbr",
                table: "pick_list_item",
                column: "po_nbr",
                principalTable: "purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items",
                column: "item_pickup_status_id",
                principalTable: "item_pickup_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pick_list_item_purchase_orders_po_nbr",
                table: "pick_list_item");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items");

            migrationBuilder.DropTable(
                name: "item_pickup_status");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_items_item_pickup_status_id",
                table: "purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_pick_list_item_po_nbr",
                table: "pick_list_item");

            migrationBuilder.DropColumn(
                name: "item_pickup_status_id",
                table: "purchase_order_items");
        }
    }
}
