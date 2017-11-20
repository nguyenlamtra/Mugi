using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class ReturnProductSubProductConfiguration
    {
        public ReturnProductSubProductConfiguration(EntityTypeBuilder<ReturnProductSubProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.ReturnProductId, e.SubProductId });

            entityBuilder.HasOne(x => x.SubProduct)
                .WithMany(x => x.ReturnProductSubProducts)
                .HasForeignKey(x => x.SubProductId);

            entityBuilder.HasOne(x => x.ReturnProduct)
                .WithMany(x => x.ReturnProductSubProducts)
                .HasForeignKey(x => x.ReturnProductId);

            entityBuilder.Property(x => x.Quantity).IsRequired();
        }
    }
}
