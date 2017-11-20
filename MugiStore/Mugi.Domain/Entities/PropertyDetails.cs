using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class PropertyDetails : BaseEntity
    {
        public virtual Property Property { get; set; }

        public int PropertyId { get; set; }

        public string PropertyValue { get; set; }

        public virtual ICollection<PropertyDetailsSubProduct> PropertyDetailsSubProducts { get; set; }
    }
}
