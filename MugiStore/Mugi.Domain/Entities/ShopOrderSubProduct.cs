using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class ShopOrderSubProduct
    {
        public int ShopOrderId { get; set; }
        public int SubProductId { get; set; }
        public int Quantity { get; set; }

        public virtual ShopOrder ShopOrder { get; set; }
        public virtual SubProduct SubProduct { get; set; }
    }
}
