using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class PromotionConfiguration
    {
        public PromotionConfiguration(EntityTypeBuilder<Promotion> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.PromotionPercent).IsRequired();
            entityBuilder.Property(x => x.BeginDay).IsRequired();
            entityBuilder.Property(x => x.EndDay).IsRequired();
        }
    }
}
