using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class GoodsReceiptProduct
    {
        public int GoodsReceiptId { get; set; }

        public int ProductId { get; set; }

        public int PriceInsert { get; set; }

        public GoodsReceipt GoodsReceipt { get; set; }

        public Product Product { get; set; }
    }
}
