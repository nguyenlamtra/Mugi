using Microsoft.EntityFrameworkCore.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Core.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private MugiStoreDbContext dbContext;
        private IRepository<Category> categoryRepository;
        private IRepository<Product> productRepository;
        private IRepository<Supplier> supplierRepository;
        private IRepository<PriceDetails> priceDetailsRepository;
        private IRepository<ImageProduct> imageProductRepository;
        private IRepository<Advertisement> advertisementRepository;
        private IRepository<SubProduct> subProductRepository;
        private IRepository<Order> orderRepository;
        private IRepository<OrderSubProduct> orderSubProductRepository;
        private IRepository<Customer> customerRepository;
        private IRepository<Account> accountRepository;
        private IRepository<SubCategory> subCategoryRepository;
        private IRepository<Property> propertyRepository;
        private IRepository<PropertyDetails> propertyDetailsRepository;
        private IRepository<GoodsReceipt> goodsReceiptRepository;
        private IRepository<Staff> staffRepository;
        private IRepository<ReturnProduct> returnProductRepository;
        private IRepository<Promotion> promotionRepository;
        private IRepository<Role> roleRepository;

        public IRepository<Role> RoleRepository
        {
            get
            {
                return roleRepository = roleRepository ?? new Repository<Role>(dbContext);
            }
        }

        public IRepository<Promotion> PromotionRepository
        {
            get
            {
                return promotionRepository = promotionRepository ?? new Repository<Promotion>(dbContext);
            }
        }

        public IRepository<ReturnProduct> ReturnProductRepository
        {
            get
            {
                return returnProductRepository = returnProductRepository ?? new Repository<ReturnProduct>(dbContext);
            }
        }

        public IRepository<Staff> StaffRepository
        {
            get
            {
                return staffRepository = staffRepository ?? new Repository<Staff>(dbContext);
            }
        }

        public IRepository<GoodsReceipt> GoodsReceiptRepository
        {
            get
            {
                return goodsReceiptRepository = goodsReceiptRepository ?? new Repository<GoodsReceipt>(dbContext);
            }
        }

        public IRepository<PropertyDetails> PropertyDetailsRepository
        {
            get
            {
                return propertyDetailsRepository = propertyDetailsRepository ?? new Repository<PropertyDetails>(dbContext);
            }
        }

        public IRepository<Property> PropertyRepository
        {
            get
            {
                return propertyRepository = propertyRepository ?? new Repository<Property>(dbContext);
            }
        }

        public IRepository<SubCategory> SubCategoryRepository
        {
            get
            {
                return subCategoryRepository = subCategoryRepository ?? new Repository<SubCategory>(dbContext);
            }
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return customerRepository = customerRepository ?? new Repository<Customer>(dbContext);
            }
        }

        public IRepository<Account> AccountRepository
        {
            get
            {
                return accountRepository = accountRepository ?? new Repository<Account>(dbContext);
            }
        }

        public IRepository<OrderSubProduct> OrderSubProductRepository
        {
            get
            {
                return orderSubProductRepository = orderSubProductRepository ?? new Repository<OrderSubProduct>(dbContext);
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return orderRepository = orderRepository ?? new Repository<Order>(dbContext);
            }
        }

        public IRepository<ImageProduct> ImageProductRepository
        {
            get
            {
                return imageProductRepository = imageProductRepository ?? new Repository<ImageProduct>(dbContext);
            }
        }

        public IRepository<PriceDetails> PriceDetailsRepository
        {
            get
            {
                return priceDetailsRepository = priceDetailsRepository ?? new Repository<PriceDetails>(dbContext);
            }
        }

        public IRepository<Supplier> SupplierRepository
        {
            get
            {
                return supplierRepository = supplierRepository ?? new Repository<Supplier>(dbContext);
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return categoryRepository = categoryRepository ?? new Repository<Category>(dbContext);
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                return productRepository = productRepository ?? new Repository<Product>(dbContext);
            }
        }

        public IRepository<Advertisement> AdvertisementRepository
        {
            get
            {
                return advertisementRepository = advertisementRepository ?? new Repository<Advertisement>(dbContext);
            }
        }

        public IRepository<SubProduct> SubProductRepository
        {
            get
            {
                return subProductRepository = subProductRepository ?? new Repository<SubProduct>(dbContext);
            }
        }

        public UnitOfWork(MugiStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
