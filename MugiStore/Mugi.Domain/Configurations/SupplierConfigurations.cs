using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class SupplierConfigurations
    {
        public SupplierConfigurations(EntityTypeBuilder<Supplier> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.SupplierName).IsUnicode(true).IsRequired();

        }
    }
}
