﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Photon.Data;

#nullable disable

namespace Photon.Migrations
{
    [DbContext(typeof(PhotonContext))]
    [Migration("20240730041749_FixPOItemFK")]
    partial class FixPOItemFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ItemMaterial", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("integer")
                        .HasColumnName("items_id");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("integer")
                        .HasColumnName("materials_id");

                    b.HasKey("ItemsId", "MaterialsId")
                        .HasName("pk_item_material");

                    b.HasIndex("MaterialsId")
                        .HasDatabaseName("ix_item_material_materials_id");

                    b.ToTable("item_material", (string)null);
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("integer")
                        .HasColumnName("permissions_id");

                    b.Property<int>("RolesId")
                        .HasColumnType("integer")
                        .HasColumnName("roles_id");

                    b.HasKey("PermissionsId", "RolesId")
                        .HasName("pk_permission_role");

                    b.HasIndex("RolesId")
                        .HasDatabaseName("ix_permission_role_roles_id");

                    b.ToTable("permission_role", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_contacts");

                    b.ToTable("contacts", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactId")
                        .HasColumnType("integer")
                        .HasColumnName("contact_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.HasIndex("ContactId")
                        .HasDatabaseName("ix_customers_contact_id");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_equipments");

                    b.ToTable("equipments", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FacilityCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("facility_code");

                    b.HasKey("Id")
                        .HasName("pk_facilities");

                    b.ToTable("facilities", (string)null);
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_inbound_purchase_order_status");

                    b.ToTable("inbound_purchase_order_status", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<DateOnly>("ExpiringDate")
                        .HasColumnType("date")
                        .HasColumnName("expiring_date");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<DateOnly>("ManufacturerDate")
                        .HasColumnType("date")
                        .HasColumnName("manufacturer_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_items_facility_id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_materials");

                    b.ToTable("materials", (string)null);
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_outbound_purchase_order_status");

                    b.ToTable("outbound_purchase_order_status", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PoNbr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("po_nbr");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PoNbr"));

                    b.Property<DateTime>("CancelDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cancel_date");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delivery_date");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer")
                        .HasColumnName("item_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ship_date");

                    b.HasKey("PoNbr")
                        .HasName("pk_purchase_order");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_purchase_order_facility_id");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_purchase_order_item_id");

                    b.ToTable("purchase_order", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrderItem", b =>
                {
                    b.Property<int>("PoNbr")
                        .HasColumnType("integer")
                        .HasColumnName("po_nbr");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer")
                        .HasColumnName("item_id");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("ordered_quantity");

                    b.Property<int>("ReceivedQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("received_quantity");

                    b.HasKey("PoNbr", "ItemId");

                    b.ToTable("purchase_order_item", (string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Photon.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Photon.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContactId")
                        .HasColumnType("integer")
                        .HasColumnName("contact_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_suppliers");

                    b.HasIndex("ContactId")
                        .HasDatabaseName("ix_suppliers_contact_id");

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("Photon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("integer")
                        .HasColumnName("equipment_id");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("first_name");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<int>("HourlyWage")
                        .HasColumnType("integer")
                        .HasColumnName("hourly_wage");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("EquipmentId")
                        .HasDatabaseName("ix_users_equipment_id");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_users_facility_id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Photon.src.Models.TheContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_the_containers");

                    b.ToTable("the_containers", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer")
                        .HasColumnName("roles_id");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer")
                        .HasColumnName("users_id");

                    b.HasKey("RolesId", "UsersId")
                        .HasName("pk_role_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_role_user_users_id");

                    b.ToTable("role_user", (string)null);
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrder", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrder");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer")
                        .HasColumnName("supplier_id");

                    b.HasIndex("StatusId")
                        .HasDatabaseName("ix_inbound_purchase_orders_status_id");

                    b.HasIndex("SupplierId")
                        .HasDatabaseName("ix_inbound_purchase_orders_supplier_id");

                    b.ToTable("inbound_purchase_orders", (string)null);
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrder", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrder");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_outbound_purchase_orders_customer_id");

                    b.HasIndex("StatusId")
                        .HasDatabaseName("ix_outbound_purchase_orders_status_id");

                    b.ToTable("outbound_purchase_orders", (string)null);
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrderItem", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrderItem");

                    b.Property<int>("InboundPurchaseOrderPoNbr")
                        .HasColumnType("integer")
                        .HasColumnName("inbound_purchase_order_po_nbr");

                    b.HasIndex("InboundPurchaseOrderPoNbr")
                        .HasDatabaseName("ix_inbound_purchase_order_items_inbound_purchase_order_po_nbr");

                    b.ToTable("inbound_purchase_order_items", (string)null);
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrderItem", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrderItem");

                    b.Property<int>("OutboundPurchaseOrderPoNbr")
                        .HasColumnType("integer")
                        .HasColumnName("outbound_purchase_order_po_nbr");

                    b.HasIndex("OutboundPurchaseOrderPoNbr")
                        .HasDatabaseName("ix_outbound_purchase_order_items_outbound_purchase_order_po_nbr");

                    b.ToTable("outbound_purchase_order_items", (string)null);
                });

            modelBuilder.Entity("ItemMaterial", b =>
                {
                    b.HasOne("Photon.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_material_items_items_id");

                    b.HasOne("Photon.Models.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_material_materials_materials_id");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("Photon.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permission_role_permissions_permissions_id");

                    b.HasOne("Photon.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permission_role_roles_roles_id");
                });

            modelBuilder.Entity("Photon.Models.Customer", b =>
                {
                    b.HasOne("Photon.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customers_contacts_contact_id");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Photon.Models.Item", b =>
                {
                    b.HasOne("Photon.Models.Facility", "Facility")
                        .WithMany("Items")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_items_facilities_facility_id");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_purchase_order_facilities_facility_id");

                    b.HasOne("Photon.Models.Item", null)
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("fk_purchase_order_items_item_id");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrderItem", b =>
                {
                    b.HasOne("Photon.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("Photon.Models.Supplier", b =>
                {
                    b.HasOne("Photon.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("fk_suppliers_contacts_contact_id");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Photon.Models.User", b =>
                {
                    b.HasOne("Photon.Models.Equipment", "Equipment")
                        .WithMany("Users")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("fk_users_equipments_equipment_id");

                    b.HasOne("Photon.Models.Facility", "Facility")
                        .WithMany("Users")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_facilities_facility_id");

                    b.Navigation("Equipment");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Photon.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_user_roles_roles_id");

                    b.HasOne("Photon.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_user_users_users_id");
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.PurchaseOrder", null)
                        .WithOne()
                        .HasForeignKey("Photon.Models.InboundPurchaseOrder", "PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inbound_purchase_orders_purchase_order_po_nbr");

                    b.HasOne("Photon.Models.InboundPurchaseOrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inbound_purchase_orders_inbound_purchase_order_status_statu");

                    b.HasOne("Photon.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inbound_purchase_orders_suppliers_supplier_id");

                    b.Navigation("Status");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_customers_customer_id");

                    b.HasOne("Photon.Models.PurchaseOrder", null)
                        .WithOne()
                        .HasForeignKey("Photon.Models.OutboundPurchaseOrder", "PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_purchase_order_po_nbr");

                    b.HasOne("Photon.Models.OutboundPurchaseOrderStatus", "Status")
                        .WithMany("OutboundPurchaseOrders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_outbound_purchase_order_status_sta");

                    b.Navigation("Customer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrderItem", b =>
                {
                    b.HasOne("Photon.Models.InboundPurchaseOrder", "InboundPurchaseOrder")
                        .WithMany("Items")
                        .HasForeignKey("InboundPurchaseOrderPoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inbound_purchase_order_items_inbound_purchase_orders_inboun");

                    b.Navigation("InboundPurchaseOrder");
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrderItem", b =>
                {
                    b.HasOne("Photon.Models.OutboundPurchaseOrder", "OutboundPurchaseOrder")
                        .WithMany()
                        .HasForeignKey("OutboundPurchaseOrderPoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_order_items_outbound_purchase_orders_outb");

                    b.Navigation("OutboundPurchaseOrder");
                });

            modelBuilder.Entity("Photon.Models.Equipment", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Photon.Models.Facility", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Photon.Models.Item", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("Photon.Models.OutboundPurchaseOrderStatus", b =>
                {
                    b.Navigation("OutboundPurchaseOrders");
                });

            modelBuilder.Entity("Photon.Models.InboundPurchaseOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
