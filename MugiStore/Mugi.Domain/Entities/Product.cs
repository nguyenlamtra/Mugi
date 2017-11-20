using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product() { }
        
        public Product(string productName, string description,
            int subCategoryId, int supplierId, string image, int[] propertyIds/*, int price*/)
        {
            this.ProductName = productName;
            this.Description = description;
            this.SubCategoryId = subCategoryId;
            this.SupplierId = supplierId;
            List<PropertyProducts> temp=new List<PropertyProducts>();
            for (int i = 0; i < propertyIds.Count(); i++)
            {
                temp.Add(new PropertyProducts(propertyIds[i], 0));
            }
            this.ImageProducts = new List<ImageProduct>();
            this.ImageProducts.Add(new ImageProduct(image));
            this.PropertyProducts = temp;
            this.IsDeleted = false;
            //this.PriceDetails = new List<PriceDetails>();
            //this.PriceDetails.Add(new PriceDetails(price));
        }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int SubCategoryId { get; set; }

        public int SupplierId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ShopOrderProduct> ShopOrderProducts { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<SubProduct> SubProducts { get; set; }

        public virtual ICollection<ImageProduct> ImageProducts { get; set; }

        public virtual ICollection<PriceDetails> PriceDetails { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }

        public virtual ICollection<PropertyProducts> PropertyProducts { get; set; }

        public virtual ICollection<GoodsReceiptProduct> GoodsReceiptProducts { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
