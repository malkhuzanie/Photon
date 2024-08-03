using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class TPT_PurchaseOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_inbound_purchase_orders_purchase_order_",
                table: "purchase_order_item");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_outbound_purchase_orders_purchase_order",
                table: "purchase_order_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "purchase_order_item");

            migrationBuilder.DropColumn(
                name: "purchase_order_po_nbr",
                table: "purchase_order_item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item",
                column: "po_nbr");

            migrationBuilder.CreateTable(
                name: "inbound_purchase_order_details",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false),
                    purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inbound_purchase_order_details", x => x.po_nbr);
                    table.ForeignKey(
                        name: "fk_inbound_purchase_order_details_inbound_purchase_orders_purc",
                        column: x => x.purchase_order_po_nbr,
                        principalTable: "inbound_purchase_orders",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inbound_purchase_order_details_purchase_order_item_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "purchase_order_item",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "outbound_purchase_order_details",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false),
                    purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outbound_purchase_order_details", x => x.po_nbr);
                    table.ForeignKey(
                        name: "fk_outbound_purchase_order_details_outbound_purchase_orders_pu",
                        column: x => x.purchase_order_po_nbr,
                        principalTable: "outbound_purchase_orders",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_outbound_purchase_order_details_purchase_order_item_po_nbr",
                        column: x => x.po_nbr,
                        principalTable: "purchase_order_item",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inbound_purchase_order_details_purchase_order_po_nbr",
                table: "inbound_purchase_order_details",
                column: "purchase_order_po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_purchase_order_details_purchase_order_po_nbr",
                table: "outbound_purchase_order_details",
                column: "purchase_order_po_nbr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inbound_purchase_order_details");

            migrationBuilder.DropTable(
                name: "outbound_purchase_order_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "purchase_order_item",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "purchase_order_po_nbr",
                table: "purchase_order_item",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_order_item",
                table: "purchase_order_item",
                column: "po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "purchase_order_po_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_inbound_purchase_orders_purchase_order_",
                table: "purchase_order_item",
                column: "purchase_order_po_nbr",
                principalTable: "inbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_outbound_purchase_orders_purchase_order",
                table: "purchase_order_item",
                column: "purchase_order_po_nbr",
                principalTable: "outbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
