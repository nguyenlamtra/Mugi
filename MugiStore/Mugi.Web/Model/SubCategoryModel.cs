using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class SubCategoryModel : BaseModel
    {
        public string SubCategoryName { get; set; }

        public string SubCategoryDescription { get; set; }

        public IList<ProductModel> Products { get; set; }
    }
}
