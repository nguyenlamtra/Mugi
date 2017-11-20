using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class PromotionProductConfiguration
    {
        public PromotionProductConfiguration(EntityTypeBuilder<PromotionProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.ProductId, e.PromotionId });

            entityBuilder.HasOne(x => x.Promotion)
                .WithMany(x => x.PromotionProducts)
                .HasForeignKey(x => x.PromotionId);

            entityBuilder.HasOne(x => x.Product)
                .WithMany(x => x.PromotionProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
