using System;

namespace Mugi.Domain.Entities
{
    public class ImageProduct : BaseEntity
    {
        public ImageProduct(string url)
        {
            this.Url = url;
        }

        public ImageProduct(int productId, string url) {
            this.ProductId = productId;
            this.Url = url;
        }

        public ImageProduct() { }

        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}