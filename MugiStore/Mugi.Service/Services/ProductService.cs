using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mugi.Service.Services
{
    public interface IProductService
    {
        Product GetForGoodsReceipt(int productId);
        IEnumerable<Product> GoodsReceiptSearch(string name);
        IEnumerable<Product> GetForSearch(string name);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsBySupplierId(int supplierId);
        IEnumerable<Product> GetAllProductsBySubCategoryId(int subCategoryId);
        IEnumerable<Product> GetAllProductsByRangePrice(int rangePrice);
        IEnumerable<Product> GetAllProductsBySupplierIds(int[] supplierIds);
        IEnumerable<Product> GetAllProductsByFilterId(int subCategoryId,
            List<int> supplierIds, int priceFilterId, int staticFilterId);
        Product GetProductById(int productId);
        IEnumerable<Property> GetAllPropertyByProductId(int productId);
        bool Add(Product product);
        IEnumerable<Product> GetForListProductView();
        Product GetForAddSubProductView(int productId);
        bool Delete(int productId);
        Product GetForUpdateProduct(int productId);
        bool Update(Product product);
        Product GetProductForAddImageView(int productId);
        IEnumerable<Product> GetAll();
        string GetProductNameWithNoTracking(int productId);
    }
    public class ProductService : IProductService
    {
        private IUnitOfWork UnitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAll()
        {
            StringBuilder include = new StringBuilder();
            include.Append("PriceDetails");
            return this.UnitOfWork.ProductRepository.GetWithNoTracking(x => x.IsDeleted == false, includeProperties: include.ToString());
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = UnitOfWork.ProductRepository
                .Get(x => x.IsDeleted == false,
                includeProperties: "ImageProducts,PriceDetails,PromotionProducts,PromotionProducts.Promotion,SubProducts");
            //var query = UnitOfWork.ProductRepository
            //    .GetIQueryable(x => x.IsDeleted == false);
            //query.Include(x => x.ImageProducts);

            //var temp = query.ToList();
            return query;
            //x => x.PromotionProducts
            //     .Select(y => y.ProductId).Contains(x.Id),
        }

        public IEnumerable<Product> GetAllProductsByFilterId(
            int subCategoryId,
            List<int> supplierIds,
            int priceFilterId,
            int staticFilterId)
        {
            //1: all; 2: <200; 3: 200-400; 4: >400;
            //static filter: 1: increase; 2: reduce; 3: time;
            var result = UnitOfWork.ProductRepository.Get(x => x.IsDeleted == false,
                orderBy: x => x.OrderByDescending(y => y.CreatedDate),
                includeProperties: "ImageProducts,PriceDetails,PromotionProducts,PromotionProducts.Promotion,Supplier,SubCategory,SubProducts"
                );

            if (subCategoryId > 0)
            {
                result = result.Where(x => x.SubCategory.Id == subCategoryId);
            }
            if (supplierIds[0] > 0)
            {
                result = result.Where(x => supplierIds.Contains(x.Supplier.Id));
            }
            if (priceFilterId > 0)
            {
                switch (priceFilterId)
                {
                    case 2:
                        result = result.Where(x => x.PriceDetails.OrderByDescending(z => z.CreatedDate)
                        .Select(y => y.Price).FirstOrDefault() < 200000);
                        break;
                    case 3:
                        result = result.Where(x => x.PriceDetails.OrderByDescending(z => z.CreatedDate)
                        .Select(y => y.Price).FirstOrDefault() >= 200000
                        && x.PriceDetails.OrderByDescending(z => z.CreatedDate)
                        .Select(y => y.Price).FirstOrDefault() <= 400000);
                        break;
                    case 4:
                        result = result.Where(x => x.PriceDetails.OrderByDescending(z => z.CreatedDate)
                        .Select(y => y.Price).FirstOrDefault() > 400000);
                        break;
                }

            }
            if (staticFilterId > 0)
            {
                switch (staticFilterId)
                {
                    case 1:
                        result = result.OrderBy(x => x.PriceDetails.OrderByDescending(y => y.CreatedDate)
                        .Select(z => z.Price).FirstOrDefault());
                        break;
                    case 2:
                        result = result.OrderByDescending(x => x.PriceDetails
                        .OrderByDescending(y => y.CreatedDate)
                        .Select(z => z.Price).FirstOrDefault());
                        break;
                    case 3:
                        result = result.OrderByDescending(x => x.CreatedDate);
                        break;
                }

            }
            return result.ToList();
        }

        public IEnumerable<Product> GetAllProductsByRangePrice(int rangePrice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProductsBySubCategoryId(int subCategoryId)
        {
            return UnitOfWork.ProductRepository.Get(x => x.SubCategory.Id == subCategoryId).ToList();
        }

        public IEnumerable<Product> GetAllProductsBySupplierId(int supplierId)
        {
            return UnitOfWork.ProductRepository.Get(x => x.Supplier.Id == supplierId).ToList();
        }

        public IEnumerable<Product> GetAllProductsBySupplierIds(int[] supplierIds)
        {
            return UnitOfWork.ProductRepository.Get(x => supplierIds.Contains(x.Supplier.Id)).ToList();
        }

        public IEnumerable<Property> GetAllPropertyByProductId(int productId)
        {
            var product = this.UnitOfWork.ProductRepository.Get(x => x.Id == productId, includeProperties: "PropertyProducts,PropertyProducts.Property").SingleOrDefault();
            return product.PropertyProducts.Select(x => x.Property).ToList();
        }

        public Product GetProductById(int productId)
        {
            StringBuilder include = new StringBuilder();
            //include.Append("PropertyProducts,PropertyProducts.Property,PropertyProducts.Property.PropertyDetails,");
            //include.Append("ImageProducts,PriceDetails,Supplier,");
            //include.Append("SubCategory");
            include.Append("ImageProducts,PriceDetails,Supplier,");
            include.Append("SubCategory,PropertyProducts,SubProducts,");
            include.Append("SubProducts.PropertyDetailsSubProducts,");
            include.Append("SubProducts.PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("PropertyProducts,PropertyProducts.Property");
            return this.UnitOfWork.ProductRepository.Get(x => x.Id == productId, includeProperties: include.ToString()
                ).SingleOrDefault();
            //return this.UnitOfWork.ProductRepository.Get(x => x.Id == productId,
            //    includeProperties: "ImageProducts,PriceDetails,Supplier," +
            //    "SubCategory,PropertyProducts,SubProducts," +
            //    "SubProducts.PropertyDetailsSubProducts," +
            //    "SubProducts.PropertyDetailsSubProducts.PropertyDetails," +
            //    "PropertyProducts,PropertyProducts.Property").SingleOrDefault();
        }

        public bool Add(Product product)
        {
            try
            {
                product.CreatedDate = DateTime.Now;
                this.UnitOfWork.ProductRepository.Add(product);
                //this.UnitOfWork.ImageProductRepository.Add(new ImageProduct());

                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public IEnumerable<Product> GetForListProductView()
        {
            return this.UnitOfWork.ProductRepository.Get(x => x.IsDeleted == false, includeProperties: "Supplier,SubProducts,PriceDetails").OrderByDescending(x => x.CreatedDate);
        }

        public Product GetForAddSubProductView(int productId)
        {
            return this.UnitOfWork.ProductRepository.Get(x => x.Id == productId,
                includeProperties: "PropertyProducts,PropertyProducts.Property," +
                "PropertyProducts.Property.PropertyDetails, ImageProducts").SingleOrDefault();
        }

        public bool Delete(int productId)
        {
            try
            {
                var product = this.UnitOfWork.ProductRepository.GetById(productId);
                if (product.IsDeleted)
                    return false;
                else
                {
                    product.IsDeleted = true;
                    this.UnitOfWork.ProductRepository.Update(product);
                    this.UnitOfWork.Save();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public Product GetForUpdateProduct(int productId)
        {
            return this.UnitOfWork.ProductRepository.GetWithNoTracking(x => x.Id == productId && x.IsDeleted == false, includeProperties: "Supplier,PriceDetails").SingleOrDefault();
        }

        public bool Update(Product product)
        {
            try
            {

                this.UnitOfWork.ProductRepository.Update(product);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }


        public Product GetProductForAddImageView(int productId)
        {
            return this.UnitOfWork.ProductRepository
                .Get(x => x.Id == productId && x.IsDeleted == false).SingleOrDefault();

        }

        public IEnumerable<Product> GetForSearch(string name)
        {
            return this.UnitOfWork.ProductRepository.Get(x => x.ProductName.Contains(name));
        }

        public IEnumerable<Product> GoodsReceiptSearch(string name)
        {
            return this.UnitOfWork.ProductRepository.Get(x => x.ProductName.Contains(name),
                includeProperties: "");
        }

        public Product GetForGoodsReceipt(int productId)
        {
            return this.UnitOfWork.ProductRepository
                .Get(x => x.IsDeleted == false && x.Id == productId,
                includeProperties: "SubProducts, SubProducts.PropertyDetailsSubProducts, " +
                "SubProducts.PropertyDetailsSubProducts.PropertyDetails, " +
                "PropertyProducts, PropertyProducts.Property").SingleOrDefault();
        }

        public string GetProductNameWithNoTracking(int productId)
        {
            return this.UnitOfWork.ProductRepository.GetWithNoTracking(x => x.Id == productId).SingleOrDefault().ProductName;
        }
    }
}
