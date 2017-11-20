using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class ShopCartViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int SubProductId { get; set; }

        public int ProductLeft { get; set; }

        public int ProductOrder { get; set; }

        public int Price { get; set; }

        public int PromotionPercent { get; set; }

        public List<PropertyDetailsModel> PropertyDetails { get; set; }

        public string ImageUrl { get; set; }
    }

}
