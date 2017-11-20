using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            CategoryModels = new List<CategoryModel>();
            ProductModels = new List<ProductModel>();
            SupplierModels = new List<SupplierModel>();
            AdvertisementModels=new List<AdvertisementModel>();
        }

        public IList<CategoryModel> CategoryModels { get; set; }

        public IList<ProductModel> ProductModels { get; set; }

        public IList<SupplierModel> SupplierModels { get; set; }

        public IList<AdvertisementModel> AdvertisementModels { get; set; }
    }
}
