using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Mugi.Domain.Entities;
using System.Linq;

namespace Mugi.Domain.Configurations
{
    public class PropertyDetailsSubProductsConfiguration
    {
        public PropertyDetailsSubProductsConfiguration(EntityTypeBuilder<PropertyDetailsSubProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.PropertyDetailsId, e.SubProductId });

            entityBuilder.HasOne(x => x.PropertyDetails)
                .WithMany(x => x.PropertyDetailsSubProducts)
                .HasForeignKey(x => x.PropertyDetailsId);

            entityBuilder.HasOne(x => x.SubProduct)
                .WithMany(x => x.PropertyDetailsSubProducts)
                .HasForeignKey(x => x.SubProductId);
        }
    }
}
