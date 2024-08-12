﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Photon.Data;

#nullable disable

namespace Photon.Migrations
{
    [DbContext(typeof(PhotonContext))]
    partial class PhotonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ItemMasterId")
                        .HasColumnType("integer")
                        .HasColumnName("item_master_id");

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

                    b.HasIndex("ItemMasterId")
                        .HasDatabaseName("ix_items_item_master_id");

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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrderStatus", b =>
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrderStatus", b =>
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.PurchaseOrder", b =>
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

                    b.Property<int?>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

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

                    b.ToTable("purchase_order", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder.PurchaseOrderItem", b =>
                {
                    b.Property<int>("PoNbr")
                        .HasColumnType("integer")
                        .HasColumnName("po_nbr");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer")
                        .HasColumnName("item_id");

                    b.Property<int>("DeliveredQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("delivered_quantity");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("ordered_quantity");

                    b.Property<int>("ShippedQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("shipped_quantity");

                    b.HasKey("PoNbr", "ItemId")
                        .HasName("pk_purchase_order_items");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_purchase_order_items_item_id");

                    b.ToTable("purchase_order_items", (string)null);

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

            modelBuilder.Entity("Photon.src.Models.Company", b =>
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
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("Photon.src.Models.ItemMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("barcode");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<int>("ItemNbr")
                        .HasColumnType("integer")
                        .HasColumnName("item_nbr");

                    b.Property<decimal>("ItemPricing")
                        .HasColumnType("numeric")
                        .HasColumnName("item_pricing");

                    b.Property<int>("MinimumOrderSize")
                        .HasColumnType("integer")
                        .HasColumnName("minimum_order_size");

                    b.Property<string>("PhysicalDimension")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("physical_dimension");

                    b.Property<decimal>("PurchaseCost")
                        .HasColumnType("numeric")
                        .HasColumnName("purchase_cost");

                    b.Property<int>("PutawayTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("putaway_type_id");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("numeric")
                        .HasColumnName("shipping_cost");

                    b.Property<string>("TechnicalSpecification")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("technical_specification");

                    b.Property<string>("TimeToManufacture")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("time_to_manufacture");

                    b.HasKey("Id")
                        .HasName("pk_item_masters");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_item_masters_company_id");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_item_masters_facility_id");

                    b.HasIndex("PutawayTypeId")
                        .HasDatabaseName("ix_item_masters_putaway_type_id");

                    b.ToTable("item_masters", (string)null);
                });

            modelBuilder.Entity("Photon.src.Models.PutawayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PutawayTypeCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("putaway_type_code");

                    b.HasKey("Id")
                        .HasName("pk_putaway_types");

                    b.ToTable("putaway_types", (string)null);
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrder", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrder.PurchaseOrder");

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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrder", b =>
                {
                    b.HasBaseType("Photon.Models.PurchaseOrder.PurchaseOrder");

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

                    b.HasOne("Photon.src.Models.ItemMaster", "ItemMaster")
                        .WithMany()
                        .HasForeignKey("ItemMasterId")
                        .HasConstraintName("fk_items_item_masters_item_master_id");

                    b.Navigation("Facility");

                    b.Navigation("ItemMaster");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder.PurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .HasConstraintName("fk_purchase_order_facilities_facility_id");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder.PurchaseOrderItem", b =>
                {
                    b.HasOne("Photon.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_purchase_order_items_items_item_id");

                    b.HasOne("Photon.Models.PurchaseOrder.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PoItems")
                        .HasForeignKey("PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_purchase_order_items_purchase_order_po_nbr");

                    b.Navigation("Item");

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

            modelBuilder.Entity("Photon.src.Models.ItemMaster", b =>
                {
                    b.HasOne("Photon.src.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_masters_companies_company_id");

                    b.HasOne("Photon.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_masters_facilities_facility_id");

                    b.HasOne("Photon.src.Models.PutawayType", "PutawayType")
                        .WithMany()
                        .HasForeignKey("PutawayTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_masters_putaway_types_putaway_type_id");

                    b.Navigation("Company");

                    b.Navigation("Facility");

                    b.Navigation("PutawayType");
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.PurchaseOrder.PurchaseOrder", null)
                        .WithOne()
                        .HasForeignKey("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrder", "PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inbound_purchase_orders_purchase_order_po_nbr");

                    b.HasOne("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrderStatus", "Status")
                        .WithMany("InboundPurchaseOrders")
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrder", b =>
                {
                    b.HasOne("Photon.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_customers_customer_id");

                    b.HasOne("Photon.Models.PurchaseOrder.PurchaseOrder", null)
                        .WithOne()
                        .HasForeignKey("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrder", "PoNbr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_purchase_order_po_nbr");

                    b.HasOne("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrderStatus", "Status")
                        .WithMany("OutboundPurchaseOrders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_outbound_purchase_orders_outbound_purchase_order_status_sta");

                    b.Navigation("Customer");

                    b.Navigation("Status");
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

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Inbound.InboundPurchaseOrderStatus", b =>
                {
                    b.Navigation("InboundPurchaseOrders");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder.Outbound.OutboundPurchaseOrderStatus", b =>
                {
                    b.Navigation("OutboundPurchaseOrders");
                });

            modelBuilder.Entity("Photon.Models.PurchaseOrder.PurchaseOrder", b =>
                {
                    b.Navigation("PoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
