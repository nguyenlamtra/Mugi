using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Domain.Configurations
{
    public class GoodsReceiptProductConfiguration
    {
        public GoodsReceiptProductConfiguration(EntityTypeBuilder<GoodsReceiptProduct> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.GoodsReceiptId, e.ProductId });

            entityBuilder.HasOne(x => x.GoodsReceipt)
                .WithMany(x => x.GoodsReceiptProducts)
                .HasForeignKey(x => x.GoodsReceiptId);

            entityBuilder.HasOne(x => x.Product)
                .WithMany(x => x.GoodsReceiptProducts)
                .HasForeignKey(x => x.ProductId);

            entityBuilder.Property(x => x.PriceInsert).IsRequired();
        }
    }
}
