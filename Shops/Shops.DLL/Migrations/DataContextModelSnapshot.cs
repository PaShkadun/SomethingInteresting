﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperMegaHyperPuperShop.DAL.Datas;

namespace Shops.DLL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.BookmarkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PersonId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.BucketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemCount")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PersonId");

                    b.ToTable("Buckets");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderInfoId");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("OrderInfos");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemCount")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderHistoryEntityId")
                        .HasColumnType("int");

                    b.Property<int>("OrderHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("OrderInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderHistoryEntityId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.PermisionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permisions");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermisionId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.BookmarkEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.BucketEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.ItemEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderHistoryEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.OrderInfoEntity", "OrderInfo")
                        .WithMany()
                        .HasForeignKey("OrderInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderInfo");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderInfoEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderItemEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.OrderHistoryEntity", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderHistoryEntityId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.PersonEntity", b =>
                {
                    b.HasOne("SuperMegaHyperPuperShop.DAL.Entities.PermisionEntity", "Permision")
                        .WithMany()
                        .HasForeignKey("PermisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permision");
                });

            modelBuilder.Entity("SuperMegaHyperPuperShop.DAL.Entities.OrderHistoryEntity", b =>
                {
                    b.Navigation("OrderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
