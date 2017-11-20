using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class PayViewModel
    {
        public PayViewModel(List<ShopCartViewModel> shopCartViewModels, int total)
        {
            this.ShopCartViewModels = shopCartViewModels;
            this.Total = total;
        }
        public List<ShopCartViewModel> ShopCartViewModels { get; set; }
        public int Total { get; set; }
    }
    
}
