using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddSubCategoryViewModel
    {
        public List<SubCategoryInAddSubCategoryView> SubCategories { get; set; }

        public List<BasicProperty> Categories { get; set; }

        public int CategoryId { get; set; }

    }
    public class SubCategoryInAddSubCategoryView : BaseModel
    {
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
        public int CategoryId { get; set; }
    }
}
