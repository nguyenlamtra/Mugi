using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class PropertyProductsConfiguration
    {
       
            public PropertyProductsConfiguration(EntityTypeBuilder<PropertyProducts> entityBuilder)
            {
                entityBuilder.HasKey(e => new { e.ProductId, e.PropertyId});

                entityBuilder.HasOne(x => x.Property)
                    .WithMany(x => x.PropertyProducts)
                    .HasForeignKey(x => x.PropertyId);

                entityBuilder.HasOne(x => x.Product)
                    .WithMany(x => x.PropertyProducts)
                    .HasForeignKey(x => x.ProductId);
            }
        
    }
}
