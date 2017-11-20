using System;
using System.Collections.Generic;

namespace Mugi.Domain.Entities
{
    public class GoodsReceipt : BaseEntity
    {
        public GoodsReceipt()
        {
            GoodsReceiptSubProducts = new List<GoodsReceiptSubProduct>();
            GoodsReceiptProducts = new List<GoodsReceiptProduct>();
        }

        public int StaffId { get; set; }
        public int ShopOrderId { get; set; }
        public DateTime CreatedDate { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual ICollection<ShopOrder> ShopOrders { get; set; }
        public virtual ICollection<GoodsReceiptSubProduct> GoodsReceiptSubProducts { get; set; }
        public virtual ICollection<GoodsReceiptProduct> GoodsReceiptProducts { get; set; }
    }
}