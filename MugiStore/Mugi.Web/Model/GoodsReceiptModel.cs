using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class GoodsReceiptModel
    {
        public int ProductId { get; set; }
        public int PriceInput { get; set; }
        public int PriceOutput { get; set; }
        public List<SubProductInGoodsReceiptModel> SubProducts { get; set; }
    }

    public class SubProductInGoodsReceiptModel
    {
        public int SubProductId { get; set; }
        public int Quantity { get; set; }
    }
}
