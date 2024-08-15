using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class CreatePickList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_orders_purchase_order_po_nbr",
                table: "inbound_purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_orders_purchase_order_po_nbr",
                table: "outbound_purchase_orders");

            // migrationBuilder.DropForeignKey(
            //     name: "fk_purchase_order_facilities_facility_id",
            //     table: "purchase_order");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_purchase_order_po_nbr",
                table: "purchase_order_items");

            migrationBuilder.DropTable(
                name: "the_containers");

            // migrationBuilder.DropPrimaryKey(
            //     name: "pk_purchase_order",
            //     table: "outbound_purchase_orders");

            // migrationBuilder.DropPrimaryKey(
            //     name: "pk_purchase_order",
            //     table: "inbound_purchase_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_order",
                table: "purchase_order");

            migrationBuilder.RenameTable(
                name: "purchase_order",
                newName: "purchase_orders");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_order_facility_id",
                table: "purchase_orders",
                newName: "ix_purchase_orders_facility_id");

            // migrationBuilder.AddPrimaryKey(
            //     name: "pk_purchase_orders",
            //     table: "outbound_purchase_orders",
            //     column: "po_nbr");

            // migrationBuilder.AddPrimaryKey(
            //     name: "pk_purchase_orders",
            //     table: "inbound_purchase_orders",
            //     column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_orders",
                table: "purchase_orders",
                column: "po_nbr");

            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_containers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pick_lists",
                columns: table => new
                {
                    pl_nbr = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pick_lists", x => x.pl_nbr);
                    table.ForeignKey(
                        name: "fk_pick_lists_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pick_list_item",
                columns: table => new
                {
                    pl_nbr = table.Column<int>(type: "integer", nullable: false),
                    po_nbr = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    pick_location = table.Column<string>(type: "text", nullable: true),
                    from_container_id = table.Column<int>(type: "integer", nullable: true),
                    to_container_id = table.Column<int>(type: "integer", nullable: true),
                    pick_list_pl_nbr = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pick_list_item", x => new { x.pl_nbr, x.po_nbr });
                    table.ForeignKey(
                        name: "fk_pick_list_item_containers_from_container_id",
                        column: x => x.from_container_id,
                        principalTable: "containers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pick_list_item_containers_to_container_id",
                        column: x => x.to_container_id,
                        principalTable: "containers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pick_list_item_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pick_list_item_pick_lists_pick_list_pl_nbr",
                        column: x => x.pick_list_pl_nbr,
                        principalTable: "pick_lists",
                        principalColumn: "pl_nbr");
                });

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_from_container_id",
                table: "pick_list_item",
                column: "from_container_id");

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_item_id",
                table: "pick_list_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_pick_list_pl_nbr",
                table: "pick_list_item",
                column: "pick_list_pl_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_pick_list_item_to_container_id",
                table: "pick_list_item",
                column: "to_container_id");

            migrationBuilder.CreateIndex(
                name: "ix_pick_lists_user_id",
                table: "pick_lists",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_orders_purchase_orders_po_nbr",
                table: "inbound_purchase_orders",
                column: "po_nbr",
                principalTable: "purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_orders_purchase_orders_po_nbr",
                table: "outbound_purchase_orders",
                column: "po_nbr",
                principalTable: "purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_purchase_orders_po_nbr",
                table: "purchase_order_items",
                column: "po_nbr",
                principalTable: "purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_orders_facilities_facility_id",
                table: "purchase_orders",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");
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
                name: "pick_lists");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "outbound_purchase_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "inbound_purchase_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_orders",
                table: "purchase_orders");

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
