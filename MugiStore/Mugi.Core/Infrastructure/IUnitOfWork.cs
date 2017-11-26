using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Category> CategoryRepository{ get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<PriceDetails> PriceDetailsRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
        IRepository<ImageProduct> ImageProductRepository { get; }
        IRepository<Advertisement> AdvertisementRepository { get; }
        IRepository<SubProduct> SubProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderSubProduct> OrderSubProductRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Account> AccountRepository { get; }
        IRepository<SubCategory> SubCategoryRepository { get; }
        IRepository<Property> PropertyRepository { get; }
        IRepository<PropertyDetails> PropertyDetailsRepository { get; }
        IRepository<GoodsReceipt> GoodsReceiptRepository { get; }
        IRepository<GoodsReceiptProduct> GoodsReceiptProductRepository { get; }
        IRepository<GoodsReceiptSubProduct> GoodsReceiptSubProductRepository { get; }
        IRepository<Staff> StaffRepository { get; }
        IRepository<ReturnProduct> ReturnProductRepository { get; }
        IRepository<Promotion> PromotionRepository { get; }
        IRepository<Role> RoleRepository { get; }
        //IRepository<ShopOrder> ShopOrderRepository { get; }

        void Save();
    }
}
