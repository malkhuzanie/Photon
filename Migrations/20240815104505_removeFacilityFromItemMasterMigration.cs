using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class removeFacilityFromItemMasterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters");

            migrationBuilder.DropIndex(
                name: "ix_item_masters_facility_id",
                table: "item_masters");

            migrationBuilder.DropColumn(
                name: "facility_id",
                table: "item_masters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "facility_id",
                table: "item_masters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_item_masters_facility_id",
                table: "item_masters",
                column: "facility_id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");
        }
    }
}
