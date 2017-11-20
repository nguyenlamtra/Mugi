using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class GoodsReceiptSubProduct
    {
        public int GoodsReceiptId { get; set; }

        public int SubProductId { get; set; }

        public int Quantity { get; set; }

        public GoodsReceipt GoodsReceipt { get; set; }

        public SubProduct SubProduct { get; set; }
    }
}
