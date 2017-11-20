using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class ReturnProductConfiguration
    {
        public ReturnProductConfiguration(EntityTypeBuilder<ReturnProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            //entityBuilder.Property(x => x.Total).IsRequired();
   
            //entityBuilder.Property(x => x.OrderId).IsRequired();
        }
    }
}
