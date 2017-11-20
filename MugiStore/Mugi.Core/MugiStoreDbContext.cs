using Microsoft.EntityFrameworkCore;
using Mugi.Domain.Configurations;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Core
{
    public class MugiStoreDbContext : DbContext
    {
        public MugiStoreDbContext(DbContextOptions<MugiStoreDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
      
        public DbSet<Customer> Customers { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ReturnProduct> ReturnProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PriceDetails> PriceDetails { get; set; }
        public DbSet<PromotionProduct> PromotionProducts { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<Property> Propertys { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<PropertyDetailsSubProduct> PropertyDetailsSubProducts { get; set; }
        public DbSet<PropertyProducts> PropertyProducts { get; set; }
        public DbSet<OrderSubProduct> OrderSubProducts { get; set; }
        //public DbSet<RoleAccount> RoleAccounts { get; set; }
        public DbSet<GoodsReceiptSubProduct> GoodsReceiptSubProducts { get; set; }
        public DbSet<ReturnProductSubProduct> ReturnProductSubProducts { get; set; }
        public DbSet<GoodsReceiptProduct> GoodsReceiptProducts { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderProduct> ShopOrderProducts { get; set; }
        public DbSet<ShopOrderSubProduct> ShopOrderSubProducts { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CategoryConfiguration(modelBuilder.Entity<Category>());
            new AccountConfiguration(modelBuilder.Entity<Account>());
            new AdvertisementConfiguration(modelBuilder.Entity<Advertisement>());
           
            new CategoryConfiguration(modelBuilder.Entity<Category>());
            new CustomerConfiguration(modelBuilder.Entity<Customer>());
            new GoodsReceiptConfiguration(modelBuilder.Entity<GoodsReceipt>());
            new ProductImageConfiguration(modelBuilder.Entity<ImageProduct>());
            new OrderConfiguration(modelBuilder.Entity<Order>());
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new PromotionConfiguration(modelBuilder.Entity<Promotion>());
            new ReturnProductConfiguration(modelBuilder.Entity<ReturnProduct>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
            new StaffConfiguration(modelBuilder.Entity<Staff>());
            new SubCategoryConfiguration(modelBuilder.Entity<SubCategory>());
            new SupplierConfigurations(modelBuilder.Entity<Supplier>());
            new PriceDetailsConfiguration(modelBuilder.Entity<PriceDetails>());
            new PromotionProductConfiguration(modelBuilder.Entity<PromotionProduct>());
            new SubProductConfiguration(modelBuilder.Entity<SubProduct>());
            new PropertyConfiguration(modelBuilder.Entity<Property>());
            new PropertyDetailsConfiguration(modelBuilder.Entity<PropertyDetails>());
            new PropertyDetailsSubProductsConfiguration(modelBuilder.Entity<PropertyDetailsSubProduct>());
            new PropertyProductsConfiguration(modelBuilder.Entity<PropertyProducts>());
            new OrderSubProductConfiguration(modelBuilder.Entity<OrderSubProduct>());
            //new RoleAccountConfiguration(modelBuilder.Entity<RoleAccount>());
            new GoodsReceiptSubProductConfiguration(modelBuilder.Entity<GoodsReceiptSubProduct>());
            new ReturnProductSubProductConfiguration(modelBuilder.Entity<ReturnProductSubProduct>());
            new GoodsReceiptProductConfiguration(modelBuilder.Entity<GoodsReceiptProduct>());
            new OrderProductConfiguration(modelBuilder.Entity<OrderProduct>());
            new ShopOrderConfiguration(modelBuilder.Entity<ShopOrder>());
            new ShopOrderSubProductConfiguration(modelBuilder.Entity<ShopOrderSubProduct>());
            new ShopOrderProductConfiguration(modelBuilder.Entity<ShopOrderProduct>());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
