using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface ISubProductService
    {
        IEnumerable<SubProduct> GetAllSubProductByProductId(int productId);
        SubProduct GetBySubProductById(int subProductId);
        IEnumerable<SubProduct> GetForShopCart(int[] subproductId);
        bool CheckSubProduct(int productId, int[] propertyDetaisId);
        bool Add(SubProduct subProduct);
        IEnumerable<SubProduct> GetProductByListSubProductId(int[] subProductId);
        int CheckBeforeCheckout(int[] subProductId);
        SubProduct GetById(int id);
        IEnumerable<SubProduct> GetForShopOrder(int[] productIds);
    }

    public class SubProductService : ISubProductService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public SubProductService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<SubProduct> GetAllSubProductByProductId(int productId)
        {
            return this.UnitOfWork.SubProductRepository.Get(x => x.Product.Id == productId).ToList();
        }

        public SubProduct GetBySubProductById(int subProductId)
        {
            return this.UnitOfWork.SubProductRepository.Get(x => x.Id == subProductId,
                includeProperties: "Product,Product.ImageProducts,Product.PriceDetails," +
                "Product.PromotionProducts,Product.PropertyProducts,Product.PropertyProducts.Property," +
                "PropertyDetailsSubProduct,PropertyDetailsSubProduct.PropertyDetails").SingleOrDefault();
        }

        public IEnumerable<SubProduct> GetForShopCart(int[] subproductId)
        {
            StringBuilder include = new StringBuilder();
            include.Append("Product,Product.ImageProducts,Product.PriceDetails,");
            include.Append("Product.PromotionProducts,Product.PromotionProducts.Promotion,");
            include.Append("PropertyDetailsSubProducts,PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("PropertyDetailsSubProducts.PropertyDetails.Property");
            return this.UnitOfWork.SubProductRepository.GetWithNoTracking(x => subproductId.Contains(x.Id),
                includeProperties: include.ToString());
        }

        public bool CheckSubProduct(int productId, int[] propertyDetaisIds)
        {
            var subProducts = this.UnitOfWork.SubProductRepository
                .Get(x => x.Product.Id == productId, includeProperties: "PropertyDetailsSubProducts");
            foreach (var item in subProducts)
            {
                int count = 0;
                foreach (var propertyDetailId in propertyDetaisIds)
                {
                    if (item.PropertyDetailsSubProducts.Select(x => x.PropertyDetailsId).Contains(propertyDetailId))
                    {
                        count++;
                    }
                }
                if (count == item.PropertyDetailsSubProducts.Count())
                {
                    return false;
                }
            }
            return true;
        }

        public bool Add(SubProduct subProduct)
        {
            try
            {
                this.UnitOfWork.SubProductRepository.Add(subProduct);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public IEnumerable<SubProduct> GetProductByListSubProductId(int[] subProductId)
        {
            return this.UnitOfWork.SubProductRepository
                .GetDistinctNoTracking(x => subProductId.Contains(x.Id),
                includeProperties: "Product,Product.PriceDetails");
        }

        public int CheckBeforeCheckout(int[] subProductId)
        {
            foreach (var i in subProductId)
            {
                var subProduct = this.UnitOfWork.SubProductRepository.GetWithNoTracking(x => x.Id == i).SingleOrDefault();
                if (subProduct != null)
                {
                    if (subProduct.ProductLeft == 0)
                    {
                        return subProduct.Id;
                    }
                }
                else
                {
                    return 0;
                }
            }
            return -1;
        }

        public SubProduct GetById(int id)
        {
            return this.UnitOfWork.SubProductRepository.GetWithNoTracking(x => x.Id == id, includeProperties: "Product").SingleOrDefault();
        }

        public IEnumerable<SubProduct> GetForShopOrder(int[] productIds)
        {
            return this.UnitOfWork.SubProductRepository.Get(x => productIds.Contains(x.Id), includeProperties: "PropertyDetailsSubProducts, PropertyDetailsSubProducts.PropertyDetails,Product,PropertyDetailsSubProducts.PropertyDetails.Property");
        }
    }
}
