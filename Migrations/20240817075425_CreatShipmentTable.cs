using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class CreatShipmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shipment_id",
                table: "inbound_purchase_orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipments", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inbound_purchase_orders_shipment_id",
                table: "inbound_purchase_orders",
                column: "shipment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_inbound_purchase_orders_shipments_shipment_id",
                table: "inbound_purchase_orders",
                column: "shipment_id",
                principalTable: "shipments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_inbound_purchase_orders_shipments_shipment_id",
                table: "inbound_purchase_orders");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropIndex(
                name: "ix_inbound_purchase_orders_shipment_id",
                table: "inbound_purchase_orders");

            migrationBuilder.DropColumn(
                name: "shipment_id",
                table: "inbound_purchase_orders");
        }
    }
}
