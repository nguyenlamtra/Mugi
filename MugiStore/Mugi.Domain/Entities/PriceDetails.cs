using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class PriceDetails : BaseEntity
    {
        public PriceDetails() { }

        public PriceDetails(int price)
        {
            this.Price = price;
            this.CreatedDate = DateTime.Now;
        }

        public PriceDetails(int price, int productId)
        {
            this.Price = price;
            this.ProductId = productId;
            this.CreatedDate = DateTime.Now;
        }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Price { get; set; }
    }
}
