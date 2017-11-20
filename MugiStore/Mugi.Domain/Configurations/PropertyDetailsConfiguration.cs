using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class PropertyDetailsConfiguration
    {
        public PropertyDetailsConfiguration(EntityTypeBuilder<PropertyDetails> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.PropertyId).IsRequired();
            entityBuilder.Property(x => x.PropertyValue).IsRequired().HasMaxLength(50);
        }
    }
}
