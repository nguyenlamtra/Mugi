using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class OrderProduct
    {
        public OrderProduct() { }

        public OrderProduct(int productId, int price)
        {
            this.ProductId = productId;
            this.Price = price;
        }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int Price { get; set; }
    }
}
