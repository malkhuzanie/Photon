﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photon.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equipments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facility_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_facilities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inbound_purchase_order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inbound_purchase_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "outbound_purchase_order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbound_purchase_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    contact_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                    table.ForeignKey(
                        name: "fk_customers_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    contact_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.id);
                    table.ForeignKey(
                        name: "fk_suppliers_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    manufacturer_date = table.Column<DateOnly>(type: "date", nullable: false),
                    expiring_date = table.Column<DateOnly>(type: "date", nullable: false),
                    facility_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_facilities_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    hourly_wage = table.Column<int>(type: "integer", nullable: false),
                    hire_date = table.Column<DateOnly>(type: "date", nullable: false),
                    facility_id = table.Column<int>(type: "integer", nullable: false),
                    equipment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_equipments_equipment_id",
                        column: x => x.equipment_id,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_facilities_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_role",
                columns: table => new
                {
                    permissions_id = table.Column<int>(type: "integer", nullable: false),
                    roles_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_role", x => new { x.permissions_id, x.roles_id });
                    table.ForeignKey(
                        name: "fk_permission_role_permissions_permissions_id",
                        column: x => x.permissions_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_permission_role_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_order",
                columns: table => new
                {
                    po_nbr = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ship_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cancel_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    facility_id = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    supplier_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    customer_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchase_order", x => x.po_nbr);
                    table.ForeignKey(
                        name: "fk_purchase_order_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_facilities_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_inbound_purchase_order_status_status_id",
                        column: x => x.status_id,
                        principalTable: "inbound_purchase_order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_outbound_purchase_order_status_status_id",
                        column: x => x.status_id,
                        principalTable: "outbound_purchase_order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_order_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_user",
                columns: table => new
                {
                    roles_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_user", x => new { x.roles_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_role_user_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_order_details",
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
                name: "ix_customers_contact_id",
                table: "customers",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_facility_id",
                table: "items",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_role_roles_id",
                table: "permission_role",
                column: "roles_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_customer_id",
                table: "purchase_order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_facility_id",
                table: "purchase_order",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_status_id",
                table: "purchase_order",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_supplier_id",
                table: "purchase_order",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_details_item_id",
                table: "purchase_order_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_details_purchase_order_po_nbr",
                table: "purchase_order_details",
                column: "purchase_order_po_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_role_user_users_id",
                table: "role_user",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_suppliers_contact_id",
                table: "suppliers",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_equipment_id",
                table: "users",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_facility_id",
                table: "users",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permission_role");

            migrationBuilder.DropTable(
                name: "purchase_order_details");

            migrationBuilder.DropTable(
                name: "role_user");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "purchase_order");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "inbound_purchase_order_status");

            migrationBuilder.DropTable(
                name: "outbound_purchase_order_status");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
