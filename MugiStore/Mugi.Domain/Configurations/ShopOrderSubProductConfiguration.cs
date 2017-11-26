using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class ShopOrderSubProductConfiguration
    {
        //public ShopOrderSubProductConfiguration(EntityTypeBuilder<ShopOrderSubProduct> entityBuilder)
        //{
        //    entityBuilder.HasKey(e => new { e.SubProductId, e.ShopOrderId });

        //    entityBuilder.HasOne(x => x.ShopOrder)
        //        .WithMany(x => x.ShopOrderSubProducts)
        //        .HasForeignKey(x => x.ShopOrderId);

        //    entityBuilder.HasOne(x => x.SubProduct)
        //        .WithMany(x => x.ShopOrderSubProducts)
        //        .HasForeignKey(x => x.SubProductId);

        //    entityBuilder.Property(x => x.Quantity).IsRequired();
        //}
    }
}
