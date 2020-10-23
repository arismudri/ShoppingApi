﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingApi;

namespace ShoppingApi.Migrations
{
    [DbContext(typeof(ShoppingDBContext))]
    [Migration("20200929072335_InitializeDatabase")]
    partial class InitializeDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingApi.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kendaraan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "makanan"
                        });
                });

            modelBuilder.Entity("ShoppingApi.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            Name = "Maria"
                        },
                        new
                        {
                            Id = 2,
                            Age = 20,
                            Name = "Mahmud"
                        });
                });

            modelBuilder.Entity("ShoppingApi.CustomerItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ItemId");

                    b.ToTable("CustomerItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            ItemId = 3
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            ItemId = 4
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2,
                            ItemId = 1
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 2,
                            ItemId = 2
                        },
                        new
                        {
                            Id = 6,
                            CustomerId = 2,
                            ItemId = 4
                        });
                });

            modelBuilder.Entity("ShoppingApi.Detail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Second",
                            Weight = 20
                        },
                        new
                        {
                            Id = 2,
                            Description = "Baru",
                            Weight = 30
                        },
                        new
                        {
                            Id = 3,
                            Description = "1 Dus",
                            Weight = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "1 Dus",
                            Weight = 13
                        });
                });

            modelBuilder.Entity("ShoppingApi.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Beat",
                            Price = 12000000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "N-Max",
                            Price = 32000000
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Sarimie",
                            Price = 1200
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "AQUA",
                            Price = 3500
                        });
                });

            modelBuilder.Entity("ShoppingApi.CustomerItem", b =>
                {
                    b.HasOne("ShoppingApi.Customer", "Customer")
                        .WithMany("CustomerItems")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingApi.Item", "Item")
                        .WithMany("CustomerItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingApi.Detail", b =>
                {
                    b.HasOne("ShoppingApi.Item", "Item")
                        .WithOne("Detail")
                        .HasForeignKey("ShoppingApi.Detail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingApi.Item", b =>
                {
                    b.HasOne("ShoppingApi.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}