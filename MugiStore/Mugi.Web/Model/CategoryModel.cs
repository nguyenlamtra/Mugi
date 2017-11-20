using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class CategoryModel : BaseModel
    {
        public CategoryModel()
        {
            SubCategoryModels = new List<SubCategoryModel>();
        }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public ICollection<SubCategoryModel> SubCategoryModels { get; set; }
    }
}
