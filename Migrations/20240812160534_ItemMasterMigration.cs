using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class ItemMasterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "item_master_id",
                table: "items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "putaway_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    putaway_type_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_putaway_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item_masters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_nbr = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    facility_id = table.Column<int>(type: "integer", nullable: false),
                    barcode = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    physical_dimension = table.Column<string>(type: "text", nullable: false),
                    technical_specification = table.Column<string>(type: "text", nullable: false),
                    minimum_order_size = table.Column<int>(type: "integer", nullable: false),
                    time_to_manufacture = table.Column<string>(type: "text", nullable: false),
                    purchase_cost = table.Column<decimal>(type: "numeric", nullable: false),
                    item_pricing = table.Column<decimal>(type: "numeric", nullable: false),
                    shipping_cost = table.Column<decimal>(type: "numeric", nullable: false),
                    putaway_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_masters", x => x.id);
                    table.ForeignKey(
                        name: "fk_item_masters_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_item_masters_facilities_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_item_masters_putaway_types_putaway_type_id",
                        column: x => x.putaway_type_id,
                        principalTable: "putaway_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_items_item_master_id",
                table: "items",
                column: "item_master_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_masters_company_id",
                table: "item_masters",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_masters_facility_id",
                table: "item_masters",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_masters_putaway_type_id",
                table: "item_masters",
                column: "putaway_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_items_item_masters_item_master_id",
                table: "items",
                column: "item_master_id",
                principalTable: "item_masters",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_items_item_masters_item_master_id",
                table: "items");

            migrationBuilder.DropTable(
                name: "item_masters");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "putaway_types");

            migrationBuilder.DropIndex(
                name: "ix_items_item_master_id",
                table: "items");

            migrationBuilder.DropColumn(
                name: "item_master_id",
                table: "items");
        }
    }
}
