using Mugi.Web.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddSubProductViewModel
    {
        public List<PropertyInAddSubProduct> Properties { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Image { get; set; }
    }

    public class PropertyInAddSubProduct:BaseModel
    {
        public List<PropertyInInserProduct> PropertyDetails { get; set; }

        public string PropertyName { get; set; }

    }
}
