using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class CreatePurchaseOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchase_order_details");

            migrationBuilder.CreateTable(
                name: "purchase_order_item",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    ordered_quantity = table.Column<int>(type: "integer", nullable: false),
                    received_quantity = table.Column<int>(type: "integer", nullable: false),
                    shipped_quantity = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchase_order_item", x => x.po_nbr);
                    table.ForeignKey(
                        name: "fk_purchase_order_item_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_item_purchase_order_purchase_order_po_nbr",
                        column: x => x.purchase_order_po_nbr,
                        principalTable: "purchase_order",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_item_item_id",
                table: "purchase_order_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_item_purchase_order_po_nbr",
                table: "purchase_order_item",
                column: "purchase_order_po_nbr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchase_order_item");

            migrationBuilder.CreateTable(
                name: "purchase_order_details",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    ordered_quantity = table.Column<int>(type: "integer", nullable: false),
                    received_quantity = table.Column<int>(type: "integer", nullable: false),
                    shipped_quantity = table.Column<int>(type: "integer", nullable: false),
                    purchase_order_po_nbr = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchase_order_details", x => x.po_nbr);
                    table.ForeignKey(
                        name: "fk_purchase_order_details_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_details_purchase_order_purchase_order_po_nbr",
                        column: x => x.purchase_order_po_nbr,
                        principalTable: "purchase_order",
                        principalColumn: "po_nbr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_details_item_id",
                table: "purchase_order_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_details_purchase_order_po_nbr",
                table: "purchase_order_details",
                column: "purchase_order_po_nbr");
        }
    }
}
