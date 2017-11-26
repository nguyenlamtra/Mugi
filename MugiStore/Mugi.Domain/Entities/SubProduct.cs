using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class SubProduct : BaseEntity
    {
        public SubProduct() { }
        
        public SubProduct(int productId, int[] propertyDetailsIds)
        {
            this.IsDeleted = false;
            this.ProductId = productId;
            this.PropertyDetailsSubProducts = new List<PropertyDetailsSubProduct>();
            foreach(var item in propertyDetailsIds)
            {
                this.PropertyDetailsSubProducts.Add(new PropertyDetailsSubProduct(item));
            }
        }

        public int ProductLeft { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public virtual ICollection<PropertyDetailsSubProduct> PropertyDetailsSubProducts { get; set; }

        public virtual ICollection<OrderSubProduct> OrderSubProducts { get; set; }

        public virtual ICollection<ReturnProductSubProduct> ReturnProductSubProducts { get; set; }

        public virtual ICollection<GoodsReceiptSubProduct> GoodsReceiptSubProducts { get; set; }

        //public virtual ICollection<ShopOrderSubProduct> ShopOrderSubProducts { get; set; }
    }
}
