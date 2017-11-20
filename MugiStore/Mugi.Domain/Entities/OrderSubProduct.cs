using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class OrderSubProduct
    {
        public int SubProductId { get; set; }

        public virtual SubProduct SubProduct { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
