using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class ListProductViewModel : BaseModel
    {
        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public int ProductLeft { get; set; }

        public int Price { get; set; }
    }
}
