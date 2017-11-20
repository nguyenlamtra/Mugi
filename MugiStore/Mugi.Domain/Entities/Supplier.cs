using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string SupplierName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual IEnumerable<ShopOrder> ShopOrders { get; set; }
    }
}
