using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<Account> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.HasAlternateKey(e => e.UserName);
            //entityBuilder.Property(x => x.UserName).HasMaxLength(20).IsRequired();
            entityBuilder.Property(x => x.Password).HasMaxLength(50).IsRequired();

        }
    }
}
