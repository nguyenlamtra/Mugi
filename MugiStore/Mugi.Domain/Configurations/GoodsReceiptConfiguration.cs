using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class GoodsReceiptConfiguration
    {
        public GoodsReceiptConfiguration(EntityTypeBuilder<GoodsReceipt> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
        }
    }
}
