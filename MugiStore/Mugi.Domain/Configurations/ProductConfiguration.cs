using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.Description).IsUnicode(true);
            entityBuilder.Property(x => x.ProductName).IsUnicode(true).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.SubCategoryId).IsRequired();
            entityBuilder.Property(x => x.SupplierId).IsRequired();
        }
    }
}
