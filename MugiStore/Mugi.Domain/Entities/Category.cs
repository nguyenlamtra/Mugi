using System.Collections;
using System.Collections.Generic;

namespace Mugi.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}