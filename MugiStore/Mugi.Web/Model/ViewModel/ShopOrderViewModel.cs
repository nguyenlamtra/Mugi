using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class ShopOrderViewModel
    {
        public int Id { get; set; }
        public int PriceInput { get; set; }
        public List<SubProductShopOrder> SubProducts { get; set; }
    }

    public class SubProductShopOrder
    {
        public int Id { get; set; }
        public int NumberProduct { get; set; }
    }
}
