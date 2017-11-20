using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class OrderDetailsViewModel
    {
        public string ProductName { get; set; }

        public int ProductOrder { get; set; }

        public int Price { get; set; }

        public List<PropertyDetailsModel> PropertyDetails { get; set; }

        public string ImageUrl { get; set; }
    }
}
