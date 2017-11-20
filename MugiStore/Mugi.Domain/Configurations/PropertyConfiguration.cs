using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class PropertyConfiguration
    {
        public PropertyConfiguration(EntityTypeBuilder<Property> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(x => x.PropertyName).IsRequired().HasMaxLength(50);
        }
    }
}
