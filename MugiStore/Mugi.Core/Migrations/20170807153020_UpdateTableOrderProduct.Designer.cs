﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Mugi.Core;
using Mugi.Domain.Entities;

namespace Mugi.Core.Migrations
{
    [DbContext(typeof(MugiStoreDbContext))]
    [Migration("20170807153020_UpdateTableOrderProduct")]
    partial class UpdateTableOrderProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mugi.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("StaffId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDescription")
                        .IsUnicode(true);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("Address");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mail")
                        .HasMaxLength(50);

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("StaffId");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("GoodsReceipts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceiptProduct", b =>
                {
                    b.Property<int>("GoodsReceiptId");

                    b.Property<int>("ProductId");

                    b.Property<int>("PriceInsert");

                    b.HasKey("GoodsReceiptId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("GoodsReceiptProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceiptSubProduct", b =>
                {
                    b.Property<int>("GoodsReceiptId");

                    b.Property<int>("SubProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("GoodsReceiptId", "SubProductId");

                    b.HasIndex("SubProductId");

                    b.ToTable("GoodsReceiptSubProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ImageProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ProductId");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Price");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.OrderSubProduct", b =>
                {
                    b.Property<int>("SubProductId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("SubProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderSubProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PriceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceDetails");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description")
                        .IsUnicode(true);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true);

                    b.Property<int>("SubCategoryId");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDay");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<DateTime>("EndDay");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PromotionPercent");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PromotionProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("PromotionId");

                    b.HasKey("ProductId", "PromotionId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Propertys");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PropertyId");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyDetailsSubProduct", b =>
                {
                    b.Property<int>("PropertyDetailsId");

                    b.Property<int>("SubProductId");

                    b.HasKey("PropertyDetailsId", "SubProductId");

                    b.HasIndex("SubProductId");

                    b.ToTable("PropertyDetailsSubProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyProducts", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("PropertyId");

                    b.HasKey("ProductId", "PropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ReturnProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("OrderId");

                    b.Property<int?>("StaffId");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StaffId");

                    b.ToTable("ReturnProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ReturnProductSubProduct", b =>
                {
                    b.Property<int>("ReturnProductId");

                    b.Property<int>("SubProductId");

                    b.Property<int>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("ReturnProductId", "SubProductId");

                    b.HasIndex("SubProductId");

                    b.ToTable("ReturnProductSubProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.RoleAccount", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("AccountId");

                    b.HasKey("RoleId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("RoleAccounts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("Address");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mail")
                        .HasMaxLength(50);

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("SubCategoryDescription")
                        .IsUnicode(true);

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.SubProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ProductId");

                    b.Property<int>("ProductLeft");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SubProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Advertisement", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Staff", "Staff")
                        .WithMany("Advertisements")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceipt", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceiptProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.GoodsReceipt", "GoodsReceipt")
                        .WithMany("GoodsReceiptProducts")
                        .HasForeignKey("GoodsReceiptId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("GoodsReceiptProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.GoodsReceiptSubProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.GoodsReceipt", "GoodsReceipt")
                        .WithMany("GoodsReceiptSubProducts")
                        .HasForeignKey("GoodsReceiptId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.SubProduct", "SubProduct")
                        .WithMany("GoodsReceiptSubProducts")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ImageProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("ImageProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Order", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.OrderSubProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Order", "Order")
                        .WithMany("OrderSubProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.SubProduct", "SubProduct")
                        .WithMany("OrderSubProducts")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PriceDetails", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("PriceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Product", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PromotionProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("PromotionProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Promotion", "Promotion")
                        .WithMany("PromotionProducts")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyDetails", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Property", "Property")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyDetailsSubProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.PropertyDetails", "PropertyDetails")
                        .WithMany("PropertyDetailsSubProducts")
                        .HasForeignKey("PropertyDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.SubProduct", "SubProduct")
                        .WithMany("PropertyDetailsSubProducts")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PropertyProducts", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("PropertyProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Property", "Property")
                        .WithMany("PropertyProducts")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ReturnProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Mugi.Domain.Entities.Staff", "Staff")
                        .WithMany("ReturnProduct")
                        .HasForeignKey("StaffId");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ReturnProductSubProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.ReturnProduct", "ReturnProduct")
                        .WithMany("ReturnProductSubProducts")
                        .HasForeignKey("ReturnProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.SubProduct", "SubProduct")
                        .WithMany("ReturnProductSubProducts")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.RoleAccount", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Account", "Account")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mugi.Domain.Entities.Role", "Role")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Staff", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Account", "Account")
                        .WithMany("Staffs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mugi.Domain.Entities.SubProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("SubProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
