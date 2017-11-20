using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class HomePageFilterViewModel
    {
        public int subCategoryId { get; set; }
        public List<int> supplierIds { get; set; }
        public int priceFilterId { get; set; }
        public int staticFilterId { get; set; }
    }
}
