using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.CategoryName).IsRequired().HasMaxLength(50).IsUnicode(true);
            entityBuilder.Property(e => e.CategoryDescription).IsUnicode(true);
        }
    }
}
