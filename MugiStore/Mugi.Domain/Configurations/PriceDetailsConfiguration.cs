using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class PriceDetailsConfiguration
    {
        public PriceDetailsConfiguration(EntityTypeBuilder<PriceDetails> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.Price).IsRequired();
            entityBuilder.Property(x => x.ProductId).IsRequired();
        }
    }
}
