using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class SubProductConfiguration
    {
        public SubProductConfiguration(EntityTypeBuilder<SubProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.ProductLeft).IsRequired();
            entityBuilder.Property(x => x.ProductId).IsRequired();
        }
    }
}
