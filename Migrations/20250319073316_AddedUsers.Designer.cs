﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDeviceManagementAPI.Migrations
{
    [DbContext(typeof(AssetManagementContext))]
    [Migration("20250319073316_AddedUsers")]
    partial class AddedUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AssetManagement")
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Employee", b =>
                {
                    b.Property<string>("empId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empId");

                    b.ToTable("Employees", "AssetManagement");

                    b.HasData(
                        new
                        {
                            empId = "E1",
                            department = "DotNet",
                            empName = "Suriya"
                        });
                });

            modelBuilder.Entity("Model.Keyboard", b =>
                {
                    b.Property<string>("keyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("empId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("keyBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("keyS_No")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("keyId");

                    b.HasIndex("empId");

                    b.ToTable("Keyboards", "AssetManagement");
                });

            modelBuilder.Entity("Model.Laptop", b =>
                {
                    b.Property<string>("empId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lapHostName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("assignedOn")
                        .HasColumnType("date");

                    b.Property<string>("lapModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empId", "lapHostName");

                    b.ToTable("Laptops", "AssetManagement");
                });

            modelBuilder.Entity("Model.Mouse", b =>
                {
                    b.Property<string>("mouseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("empId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("mouseBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mouseS_No")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("mouseId");

                    b.HasIndex("empId");

                    b.ToTable("Mouses", "AssetManagement");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("empId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("empId");

                    b.ToTable("Users", "AssetManagement");

                    b.HasData(
                        new
                        {
                            id = 1,
                            password = "admin",
                            role = "Admin",
                            userName = "admin"
                        },
                        new
                        {
                            id = 2,
                            empId = "E1",
                            password = "e1",
                            role = "Employee",
                            userName = "e1"
                        });
                });

            modelBuilder.Entity("Model.Keyboard", b =>
                {
                    b.HasOne("Model.Employee", "Employee")
                        .WithMany("Keyboards")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.Laptop", b =>
                {
                    b.HasOne("Model.Employee", "Employee")
                        .WithMany("Laptops")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.Mouse", b =>
                {
                    b.HasOne("Model.Employee", "Employee")
                        .WithMany("Mouses")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("empId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.Employee", b =>
                {
                    b.Navigation("Keyboards");

                    b.Navigation("Laptops");

                    b.Navigation("Mouses");
                });
#pragma warning restore 612, 618
        }
    }
}
