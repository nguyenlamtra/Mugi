using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class AdvertisementConfiguration
    {
        public AdvertisementConfiguration(EntityTypeBuilder<Advertisement> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.Url).HasMaxLength(100);
        }
    }
}
