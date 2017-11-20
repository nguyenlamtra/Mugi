using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class OrderProductConfiguration
    {
        public OrderProductConfiguration(EntityTypeBuilder<OrderProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.ProductId, e.OrderId });

            entityBuilder.HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.OrderId);

            entityBuilder.HasOne(x => x.Product)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductId);

            entityBuilder.Property(x => x.Price).IsRequired();
        }
    }
}
