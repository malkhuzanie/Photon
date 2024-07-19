using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullableUserEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_equipments_equipment_id",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "equipment_id",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_users_equipments_equipment_id",
                table: "users",
                column: "equipment_id",
                principalTable: "equipments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_equipments_equipment_id",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "equipment_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_equipments_equipment_id",
                table: "users",
                column: "equipment_id",
                principalTable: "equipments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
