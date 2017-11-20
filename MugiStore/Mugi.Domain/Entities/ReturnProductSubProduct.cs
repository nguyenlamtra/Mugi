using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class ReturnProductSubProduct
    {
        public int ReturnProductId { get; set; }

        public ReturnProduct ReturnProduct { get; set; }

        public int SubProductId { get; set; }

        public SubProduct SubProduct { get; set; }

        public int Quantity { get; set; }
    }
}
