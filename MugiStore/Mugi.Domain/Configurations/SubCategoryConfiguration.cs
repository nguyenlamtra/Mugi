using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class SubCategoryConfiguration
    {
        public SubCategoryConfiguration(EntityTypeBuilder<SubCategory> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.SubCategoryName).IsUnicode(true).IsRequired();
            entityBuilder.Property(e => e.SubCategoryDescription).IsUnicode(true);
            entityBuilder.Property(x => x.CategoryId).IsRequired();

        }
    }
}
