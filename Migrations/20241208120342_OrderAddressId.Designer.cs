﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectMPA.Models.Data;

#nullable disable

namespace ProiectMPA.Migrations
{
    [DbContext(typeof(ProiectMPADbContext))]
    [Migration("20241208120342_OrderAddressId")]
    partial class OrderAddressId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("ProiectMPA.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Start your meal with a delicious appetizer.",
                            Name = "Appetizers"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hearty and satisfying main courses.",
                            Name = "Main Courses"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sweet treats to end your meal.",
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("ProiectMPA.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("ProiectMPA.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Crispy rolls with a savory filling.",
                            ImageURL = "https://www.vegrecipesofindia.com/wp-content/uploads/2015/10/spring-rolls-recipe.jpg",
                            Name = "Spring Rolls",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Grilled bread with tomato and basil.",
                            ImageURL = "https://www.thespruceeats.com/thmb/0SP-Ui3K2C2jL5OkUvIQopCqVHo=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/how-to-make-bruschetta-2020459-hero-01-15950eb2b852461abc9cfbbf536382dd.jpg",
                            Name = "Bruschetta",
                            Price = 6.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Juicy grilled chicken with herbs.",
                            ImageURL = "https://www.thespruceeats.com/thmb/x7_ajSUFbjtLdfnIYCEl2Cplhfc=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/chickenmarsala-589de2165f9b58819c883593.jpg",
                            Name = "Grilled Chicken",
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Classic Italian pasta with creamy sauce.",
                            ImageURL = "https://www.thespruceeats.com/thmb/sUSIS7lVuErRIJHonesrPRjhXQQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/pasta-carbonara-recipe-5210168-hero-01-80090e56abc04ca19d88ebf7fad1d157.jpg",
                            Name = "Spaghetti Carbonara",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Rich and moist chocolate cake.",
                            ImageURL = "https://www.thespruceeats.com/thmb/Y-wYwozMefSplJE_SNjFuQHVwOo=/425x300/filters:max_bytes(150000):strip_icc():format(webp)/chocolatelayercake-157558344-56c9e3113df78cfb37910f40.jpg",
                            Name = "Chocolate Cake",
                            Price = 6.99m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Creamy cheesecake with a graham cracker crust.",
                            ImageURL = "https://www.thespruceeats.com/thmb/gYQ1Y9rrhdv-Iul_QRPzQj_Bth4=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/cheesecake-1965daae33964b7e9507301678fd94f0.jpeg",
                            Name = "Cheesecake",
                            Price = 7.99m
                        });
                });

            modelBuilder.Entity("ProiectMPA.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialMentions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProiectMPA.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ProiectMPA.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("ProiectMPA.Models.DeliveryAddress", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProiectMPA.Models.MenuItem", b =>
                {
                    b.HasOne("ProiectMPA.Models.Category", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProiectMPA.Models.Order", b =>
                {
                    b.HasOne("ProiectMPA.Models.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProiectMPA.Models.OrderItem", b =>
                {
                    b.HasOne("ProiectMPA.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectMPA.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ProiectMPA.Models.OrderStatus", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProiectMPA.Models.Order", "Order")
                        .WithMany("Statuses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ProiectMPA.Models.Category", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("ProiectMPA.Models.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}