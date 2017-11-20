using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class SessionModel
    {
        public SessionModel()
        {
            Products = new List<ProductInSessionModel>();
        }

        public List<ProductInSessionModel> Products { get; set; }

        public string CustomerName {get;set;}

        public int CustomerId { get; set; }
    }

    public class ProductInSessionModel
    {
        public int SubProductId { get; set; }

        public int NumberProduct { get; set; }
    }
}
