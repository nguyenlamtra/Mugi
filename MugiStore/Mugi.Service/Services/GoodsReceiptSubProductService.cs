using Mugi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IGoodsReceiptSubProductService
    {
        decimal GetTotalPay(int subProductId, int quantity, DateTime createDate);
    }

    public class GoodsReceiptSubProductService : IGoodsReceiptSubProductService
    {
        private IUnitOfWork UnitOfWork;

        public GoodsReceiptSubProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public decimal GetTotalPay(int subProductId, int quantity, DateTime createDate)
        {
            int skip = 0, take = 1;
            decimal totalPay = 0;
            while (true)
            {
                var goodsReceipts = UnitOfWork.GoodsReceiptRepository
                    .GetWithTakeAndSkip(skip, take, x => x.CreatedDate < createDate &&
                      x.GoodsReceiptSubProducts.Select(y => y.SubProductId).Contains(subProductId),
                    includeProperties: "GoodsReceiptSubProducts,GoodsReceiptSubProducts.SubProduct,GoodsReceiptProducts",
                    orderBy: x => x.OrderByDescending(y => y.CreatedDate)).SingleOrDefault();
                var goodsReceiptSubProduct = goodsReceipts.GoodsReceiptSubProducts
                    .Where(x => x.SubProductId == subProductId).FirstOrDefault();
                var goodsReceiptProduct = goodsReceipts.GoodsReceiptProducts
                    .Where(x => x.ProductId == goodsReceiptSubProduct.SubProduct.ProductId).SingleOrDefault();

                //var goodsReceiptSubProduct = UnitOfWork.GoodsReceiptSubProductRepository
                //    .GetWithTakeAndSkip(skip, take, x => x.SubProductId == subProductId
                //    , includeProperties: "SubProduct,GoodsReceipt,GoodsReceipt.GoodsReceiptProducts").SingleOrDefault();
                //var goodsReceiptProduct = goodsReceiptSubProduct.GoodsReceipt
                //    .GoodsReceiptProducts.Where(x => x.ProductId == goodsReceiptSubProduct.SubProduct.ProductId).SingleOrDefault();
                if (goodsReceiptSubProduct.Quantity < quantity)
                {
                    totalPay += goodsReceiptSubProduct.Quantity * goodsReceiptProduct.PriceInsert;
                    quantity -= goodsReceiptSubProduct.Quantity;
                    skip++;
                }
                else
                {
                    totalPay += quantity * goodsReceiptProduct.PriceInsert;
                    break;
                }
            }
            return totalPay;
        }
    }
}
