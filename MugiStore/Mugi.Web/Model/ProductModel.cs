using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class ProductModel : BaseModel
    {
        public ProductModel()
        {
            PriceDetails = new PriceDetailsModel();
            ImageProducts = new List<ImageProductModel>();
            PriceDetails = new PriceDetailsModel();
            SubProducts = new List<SubProductModel>();
        }

        public SubCategoryModel SubCategory { get; set; }

        public SupplierModel Supplier { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public IList<SubProductModel> SubProducts { get; set; }

        public int ProductLeft { get; set; }

        public PromotionModel Promotion { get; set; }

        public PriceDetailsModel PriceDetails { get; set; }

        public List<ImageProductModel> ImageProducts { get; set; }
    }
}
