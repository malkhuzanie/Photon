using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class itemMasterEditMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_companies_company_id",
                table: "item_masters");

            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters");

            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_putaway_types_putaway_type_id",
                table: "item_masters");

            migrationBuilder.DropColumn(
                name: "item_nbr",
                table: "item_masters");

            migrationBuilder.AlterColumn<int>(
                name: "putaway_type_id",
                table: "item_masters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "item_masters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "item_masters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_companies_company_id",
                table: "item_masters",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_putaway_types_putaway_type_id",
                table: "item_masters",
                column: "putaway_type_id",
                principalTable: "putaway_types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_companies_company_id",
                table: "item_masters");

            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters");

            migrationBuilder.DropForeignKey(
                name: "fk_item_masters_putaway_types_putaway_type_id",
                table: "item_masters");

            migrationBuilder.AlterColumn<int>(
                name: "putaway_type_id",
                table: "item_masters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "item_masters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "item_masters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "item_nbr",
                table: "item_masters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_companies_company_id",
                table: "item_masters",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_facilities_facility_id",
                table: "item_masters",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_item_masters_putaway_types_putaway_type_id",
                table: "item_masters",
                column: "putaway_type_id",
                principalTable: "putaway_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
