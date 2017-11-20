using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class GoodsReceiptSubProductConfiguration
    {
        public GoodsReceiptSubProductConfiguration(EntityTypeBuilder<GoodsReceiptSubProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.GoodsReceiptId, e.SubProductId});

            entityBuilder.HasOne(x => x.GoodsReceipt)
                .WithMany(x => x.GoodsReceiptSubProducts)
                .HasForeignKey(x => x.GoodsReceiptId);

            entityBuilder.HasOne(x => x.SubProduct)
                .WithMany(x => x.GoodsReceiptSubProducts)
                .HasForeignKey(x => x.SubProductId);

            entityBuilder.Property(x => x.Quantity).IsRequired();
        }
    }
}
