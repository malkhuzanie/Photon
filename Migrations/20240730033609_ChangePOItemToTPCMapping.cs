using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class ChangePOItemToTPCMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_item_items_item_id",
                table: "purchase_order_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_item_item_id",
                table: "purchase_order_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_outbound_purchase_order_items_purchase_order_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_inbound_purchase_order_items_purchase_order_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.RenameColumn(
                name: "purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                newName: "received_quantity");

            migrationBuilder.RenameColumn(
                name: "purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                newName: "received_quantity");

            migrationBuilder.AlterColumn<int>(
                name: "po_nbr",
                table: "purchase_order_item",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "item_id",
                table: "purchase_order",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "item_id",
                table: "outbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ordered_quantity",
                table: "outbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "outbound_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "item_id",
                table: "inbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "inbound_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ordered_quantity",
                table: "inbound_purchase_order_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items",
                columns: new[] { "po_nbr", "item_id" });

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_item_id",
                table: "purchase_order",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_purchase_order_items_outbound_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                column: "outbound_purchase_order_po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_purchase_order_items_inbound_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                column: "inbound_purchase_order_po_nbr");

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_order_items_inbound_purchase_orders_inboun",
                table: "inbound_purchase_order_items",
                column: "inbound_purchase_order_po_nbr",
                principalTable: "inbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_outbound_purchase_order_items_outbound_purchase_orders_outb",
                table: "outbound_purchase_order_items",
                column: "outbound_purchase_order_po_nbr",
                principalTable: "outbound_purchase_orders",
                principalColumn: "po_nbr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_items_item_id",
                table: "purchase_order",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_order_items_inbound_purchase_orders_inboun",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_outbound_purchase_order_items_outbound_purchase_orders_outb",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_items_item_id",
                table: "purchase_order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item");

            migrationBuilder.DropIndex(
                name: "ix_purchase_order_item_id",
                table: "purchase_order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_outbound_purchase_order_items_outbound_purchase_order_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropIndex(
                name: "ix_inbound_purchase_order_items_inbound_purchase_order_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "purchase_order");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "ordered_quantity",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "outbound_purchase_order_po_nbr",
                table: "outbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "inbound_purchase_order_po_nbr",
                table: "inbound_purchase_order_items");

            migrationBuilder.DropColumn(
                name: "ordered_quantity",
                table: "inbound_purchase_order_items");

            migrationBuilder.RenameColumn(
                name: "received_quantity",
                table: "outbound_purchase_order_items",
                newName: "purchase_order_po_nbr");

            migrationBuilder.RenameColumn(
                name: "received_quantity",
                table: "inbound_purchase_order_items",
                newName: "purchase_order_po_nbr");

            migrationBuilder.AlterColumn<int>(
                name: "po_nbr",
                table: "purchase_order_item",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_order_item",
                table: "purchase_order_item",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_outbound_purchase_order_items",
                table: "outbound_purchase_order_items",
                column: "po_nbr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inbound_purchase_order_items",
                table: "inbound_purchase_order_items",
                column: "po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_item_item_id",
                table: "purchase_order_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_purchase_order_items_purchase_order_po_nbr",
                table: "outbound_purchase_order_items",
                column: "purchase_order_po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_purchase_order_items_purchase_order_po_nbr",
                table: "inbound_purchase_order_items",
                column: "purchase_order_po_nbr");

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

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_item_items_item_id",
                table: "purchase_order_item",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
