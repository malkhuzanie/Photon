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
    [Migration("20240523095021_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<int>("EquipmentId")
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

                    b.HasIndex("EquipmentId")
                        .HasDatabaseName("ix_users_equipment_id");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_users_facility_id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username");

                    b.ToTable("users", (string)null);
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

            modelBuilder.Entity("Photon.Models.User", b =>
                {
                    b.HasOne("Photon.Models.Equipment", "Equipment")
                        .WithMany("Users")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
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

            modelBuilder.Entity("Photon.Models.Equipment", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Photon.Models.Facility", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
