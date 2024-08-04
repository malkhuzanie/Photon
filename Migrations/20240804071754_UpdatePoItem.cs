using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_facilities_facility_id",
                table: "purchase_order");

            migrationBuilder.RenameColumn(
                name: "received_quantity",
                table: "purchase_order_items",
                newName: "delivered_quantity");

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "purchase_order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_facilities_facility_id",
                table: "purchase_order",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchase_order_facilities_facility_id",
                table: "purchase_order");

            migrationBuilder.RenameColumn(
                name: "delivered_quantity",
                table: "purchase_order_items",
                newName: "received_quantity");

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "purchase_order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_order_facilities_facility_id",
                table: "purchase_order",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
