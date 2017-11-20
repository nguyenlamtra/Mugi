using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Mugi.Core;
using Mugi.Domain.Entities;

namespace Mugi.Core.Migrations
{
    [DbContext(typeof(MugiStoreDbContext))]
    [Migration("20170714033401_AddTable_PromotionProduct")]
    partial class AddTable_PromotionProduct
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

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

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

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("StaffId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Bill", b =>
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

                    b.Property<int>("OrderId");

                    b.Property<int>("StaffId");

                    b.Property<int>("Total");

                    b.Property<int>("TypePaymentId");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDescription")
                        .IsUnicode(true);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
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

                    b.Property<string>("Address");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mail");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

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

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.ToTable("GoodsReceipts");
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

                    b.Property<int?>("ProductId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageProducts");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PaymentType", b =>
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

                    b.Property<string>("PaymentTypeName");

                    b.HasKey("Id");

                    b.ToTable("TypePayments");
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

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceDetails");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description")
                        .IsUnicode(true);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ProductLeft");

                    b.Property<string>("ProductName")
                        .IsUnicode(true);

                    b.Property<string>("Size");

                    b.Property<int?>("SubCategoryId");

                    b.Property<int?>("SupplierId");

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

                    b.Property<int>("PayNumber");

                    b.Property<int?>("ProductId");

                    b.Property<int>("PromotionPercent");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

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

            modelBuilder.Entity("Mugi.Domain.Entities.ReturnProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("StaffId");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.ToTable("ReturnProducts");
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

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mail");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

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
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
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
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.ImageProduct", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("ImageProducts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.PriceDetails", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany("PriceDetails")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Product", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId");

                    b.HasOne("Mugi.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Mugi.Domain.Entities.Promotion", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
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

            modelBuilder.Entity("Mugi.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("Mugi.Domain.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
