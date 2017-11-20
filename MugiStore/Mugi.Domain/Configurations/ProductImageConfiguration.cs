using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class ProductImageConfiguration
    {
        public ProductImageConfiguration(EntityTypeBuilder<ImageProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.Url).IsRequired();
            entityBuilder.Property(x => x.ProductId).IsRequired();
        }
    }
}
