using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class ShopOrder : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public int SupplierId { get; set; }
        public int GoodsReceiptId { get; set; }

        public virtual GoodsReceipt GoodsReceipt { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual IEnumerable<ShopOrderProduct> ShopOrderProducts { get; set; }
        public virtual IEnumerable<ShopOrderSubProduct> ShopOrderSubProducts { get; set; }
    }
}
