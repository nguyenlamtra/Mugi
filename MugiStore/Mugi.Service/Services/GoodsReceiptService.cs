using System.Linq;
using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IGoodsReceiptService
    {
        bool Add(GoodsReceipt goodsReceipt, List<PriceDetails> priceDetails, int staffId);
        IEnumerable<GoodsReceipt> GetAll();
        GoodsReceipt GetWithSkipTakeStatistical(int skip, int take);
    }
    public class GoodsReceiptService : IGoodsReceiptService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GoodsReceiptService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public bool Add(GoodsReceipt goodsReceipt, List<PriceDetails> priceDetails, int staffId)
        {
            try
            {
                goodsReceipt.CreatedDate = DateTime.Now;
                goodsReceipt.StaffId = staffId;
                foreach (var item in priceDetails)
                {
                    this.UnitOfWork.PriceDetailsRepository.Add(item);
                }
                foreach (var item in goodsReceipt.GoodsReceiptSubProducts)
                {
                    var subProduct = this.UnitOfWork.SubProductRepository.GetById(item.SubProductId);
                    subProduct.ProductLeft += item.Quantity;
                    this.UnitOfWork.SubProductRepository.UpdateOneField(subProduct, "ProductLeft");
                }
                this.UnitOfWork.GoodsReceiptRepository.Add(goodsReceipt);

                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public IEnumerable<GoodsReceipt> GetAll()
        {
            return UnitOfWork.GoodsReceiptRepository
                .Get(includeProperties: "GoodsReceiptSubProducts,GoodsReceiptProducts,GoodsReceiptSubProducts.SubProduct");
        }

        public GoodsReceipt GetWithSkipTakeStatistical(int skip, int take)
        {
            return UnitOfWork.GoodsReceiptRepository
                .GetWithTakeAndSkip(skip, take, includeProperties:
                "GoodsReceiptSubProducts,GoodsReceiptProducts,GoodsReceiptSubProducts.SubProduct").FirstOrDefault();
        }
    }
}
