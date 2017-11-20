using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(x => x.PaymentType).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Total).IsRequired();
            entityBuilder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            entityBuilder.Property(x => x.Address).IsRequired();
            entityBuilder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            entityBuilder.HasOne(x => x.Deliver).WithMany(x => x.DeliverOrders).HasForeignKey(x => x.DeliverId);
            entityBuilder.HasOne(x => x.Confirm).WithMany(x => x.ConfirmOrders).HasForeignKey(x => x.ConfirmId);
            entityBuilder.HasOne(x => x.Complete).WithMany(x => x.CompleteOrders).HasForeignKey(x => x.CompleteId);
            //entityBuilder.HasOne<Staff>().WithMany(x => x.DeliverOrders).HasForeignKey(x => x.DeliverId);
            //entityBuilder.HasOne<Staff>().WithMany(x => x.DeliverOrders).HasForeignKey(x => x.DeliverId);

        }
    }
}
