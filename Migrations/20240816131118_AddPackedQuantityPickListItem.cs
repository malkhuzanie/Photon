using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class AddPackedQuantityPickListItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "packed_quantity",
                table: "purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_orders_purchase_orders_po_nbr",
                table: "inbound_purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_orders_purchase_orders_po_nbr",
                table: "outbound_purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_item_pickup_status_item_pickup_status_",
                table: "purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_purchase_orders_po_nbr",
                table: "purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_orders_facilities_facility_id",
                table: "purchase_orders");

            migrationBuilder.DropTable(
                name: "pick_list_item");

            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "item_pickup_status");

            migrationBuilder.DropTable(
                name: "pick_lists");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_items_item_pickup_status_id",
                table: "purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "outbound_purchase_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "inbound_purchase_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "item_pickup_status_id",
                table: "purchase_order_items");

            migrationBuilder.DropColumn(
                name: "packed_quantity",
                table: "purchase_order_items");

            migrationBuilder.RenameTable(
                name: "purchase_orders",
                newName: "purchase_order");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_orders_facility_id",
                table: "purchase_order",
                newName: "ix_purchase_order_facility_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order",
                table: "outbound_purchase_orders",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order",
                table: "inbound_purchase_orders",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order",
                table: "purchase_order",
                column: "po_nbr");

            migrationBuilder.CreateTable(
                name: "the_containers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_the_containers", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_orders_purchase_order_po_nbr",
                table: "inbound_purchase_orders",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_orders_purchase_order_po_nbr",
                table: "outbound_purchase_orders",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_facilities_facility_id",
                table: "purchase_order",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_purchase_order_po_nbr",
                table: "purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
