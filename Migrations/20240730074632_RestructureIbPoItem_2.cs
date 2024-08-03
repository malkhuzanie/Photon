using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class RestructureIbPoItem_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropTable(
                name: "inbound_purchase_order_items");

            migrationBuilder.DropTable(
                name: "outbound_purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_purchase_order_po_nbr",
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
                name: "fk_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.CreateTable(
                name: "inbound_purchase_order_items",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    ordered_quantity = table.Column<int>(type: "integer", nullable: false),
                    received_quantity = table.Column<int>(type: "integer", nullable: false),
                    shipped_quantity = table.Column<int>(type: "integer", nullable: false),
                    inbound_purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inbound_purchase_order_items", x => new { x.po_nbr, x.item_id });
                    table.ForeignKey(
                        name: "FK_inbound_purchase_order_items_purchase_order_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "purchase_order",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inbound_purchase_order_items_inbound_purchase_orders_inboun",
                        column: x => x.inbound_purchase_order_po_nbr,
                        principalTable: "inbound_purchase_orders",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_item_items_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "outbound_purchase_order_items",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    ordered_quantity = table.Column<int>(type: "integer", nullable: false),
                    received_quantity = table.Column<int>(type: "integer", nullable: false),
                    shipped_quantity = table.Column<int>(type: "integer", nullable: false),
                    outbound_purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outbound_purchase_order_items", x => new { x.po_nbr, x.item_id });
                    table.ForeignKey(
                        name: "FK_outbound_purchase_order_items_purchase_order_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "purchase_order",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_outbound_purchase_order_items_outbound_purchase_orders_outb",
                        column: x => x.outbound_purchase_order_po_nbr,
                        principalTable: "outbound_purchase_orders",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_item_items_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inbound_purchase_order_items_inbound_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                column: "inbound_purchase_order_po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_purchase_order_items_outbound_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                column: "outbound_purchase_order_po_nbr");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "po_nbr",
                principalTable: "purchase_order",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
