using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class ShopOrderConfiguration
    {
        public ShopOrderConfiguration(EntityTypeBuilder<ShopOrder> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            //entityBuilder.HasOne<Staff>().WithMany(x => x.DeliverOrders).HasForeignKey(x => x.DeliverId);
            //entityBuilder.HasOne<Staff>().WithMany(x => x.DeliverOrders).HasForeignKey(x => x.DeliverId);
        }
    }
}
