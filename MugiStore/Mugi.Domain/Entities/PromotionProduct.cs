using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Entities
{
    public class PromotionProduct
    {
        public PromotionProduct() { }

        public PromotionProduct(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
