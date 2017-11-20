using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class OrderedViewModel
    {
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumberProduct { get; set; }
        public List<SubProductOrderedViewModel> SubProductOrderedViewModels { get; set; }
        public List<ProductOrderedViewModel> ProductOrderedViewModels { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public int Total { get; set; }
    }

    public class ProductOrderedViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
    }

    public class SubProductOrderedViewModel
    {
        public int ProductId { get; set; }
        public OrderedViewModel OrderedViewModel { get; set; }
        public int SubProductId { get; set; }
        public List<PropertyDetailsOfOrderd> PropertyDetails { get; set; }
        public int NumberSubProduct { get; set; }
    }

    public class PropertyDetailsOfOrderd
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
