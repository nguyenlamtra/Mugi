using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class ProductForGoodsReceiptModel
    {
        public int Id { get; set; }
        public List<SubProductForGoodsReceiptModel> SubProducts { get; set; }
        public List<PropertyForGoodsReceiptModel> Properties { get; set; }
        public string ProductName { get; set; }
        public int PriceInput { get; set; }
        public int PriceOutput { get; set; }
    }

    public class SubProductForGoodsReceiptModel
    {
        public int Id { get; set; }
        public int ProductLeft { get; set; }
        public int NumberProduct { get; set; }
        public List<PropertyDetailForGoodsReceiptModel> PropertyDetails { get; set; }
    }

    public class PropertyDetailForGoodsReceiptModel
    {
        public int Id { get; set; }
        public string PropertyValue { get; set; }
        public PropertyForGoodsReceiptModel Property { get; set; }
    }

    public class PropertyForGoodsReceiptModel
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
    }
}
