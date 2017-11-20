using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class OrderSubProductConfiguration
    {
        public OrderSubProductConfiguration(EntityTypeBuilder<OrderSubProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.SubProductId, e.OrderId });

            entityBuilder.HasOne(x => x.Order)
                .WithMany(x => x.OrderSubProducts)
                .HasForeignKey(x => x.OrderId);

            entityBuilder.HasOne(x => x.SubProduct)
                .WithMany(x => x.OrderSubProducts)
                .HasForeignKey(x => x.SubProductId);

            entityBuilder.Property(x => x.Quantity).IsRequired();
        }
    }
}
