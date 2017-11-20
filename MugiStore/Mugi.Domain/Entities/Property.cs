using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class Property : BaseEntity
    {
        public string PropertyName { get; set; }

        public virtual ICollection<PropertyDetails> PropertyDetails { get; set; }

        public virtual ICollection<PropertyProducts> PropertyProducts { get; set; }
    }
}
