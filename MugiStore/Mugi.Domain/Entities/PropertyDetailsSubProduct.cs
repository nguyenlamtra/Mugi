using System;
using System.Collections.Generic;
using System.Text;


namespace Mugi.Domain.Entities
{
    public class PropertyDetailsSubProduct
    {
        public PropertyDetailsSubProduct() { }

        public PropertyDetailsSubProduct(int propertyDetailsId)
        {
            this.PropertyDetailsId = propertyDetailsId;
        }

        public int PropertyDetailsId { get; set; }

        public virtual PropertyDetails PropertyDetails { get; set; }

        public int SubProductId { get; set; }

        public virtual SubProduct SubProduct { get; set; }
    }
}
