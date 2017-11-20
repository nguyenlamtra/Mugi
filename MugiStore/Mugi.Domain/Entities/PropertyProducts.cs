using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class PropertyProducts
    {
        public PropertyProducts() { }

        public PropertyProducts(int propertyId, int productId)
        {
            this.PropertyId = propertyId;
            this.ProductId = productId;
        }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
