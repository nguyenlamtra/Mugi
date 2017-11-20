using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class ShopOrderProductConfiguration
    {
        public ShopOrderProductConfiguration(EntityTypeBuilder<ShopOrderProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.ProductId, e.ShopOrderId });

            entityBuilder.HasOne(x => x.ShopOrder)
                .WithMany(x => x.ShopOrderProducts)
                .HasForeignKey(x => x.ShopOrderId);

            entityBuilder.HasOne(x => x.Product)
                .WithMany(x => x.ShopOrderProducts)
                .HasForeignKey(x => x.ProductId);
            
        }
    }
}
