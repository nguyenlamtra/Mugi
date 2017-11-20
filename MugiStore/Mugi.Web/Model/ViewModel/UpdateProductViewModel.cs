using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class UpdateProductViewModel : BaseModel
    {
        public UpdateProductViewModel()
        {
            this.Suppliers = new List<BasicProperty>();
        }

        public string Description { get; set; }

        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public int SubCategoryId { get; set; }

        public int Price { get; set; }

        public List<BasicProperty> Suppliers { get; set; }

        public List<BasicProperty> SubCategories { get; set; }
    }
}
