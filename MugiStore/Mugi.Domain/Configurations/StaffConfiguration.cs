﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class StaffConfiguration
    {
        public StaffConfiguration(EntityTypeBuilder<Staff> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            //entityBuilder.HasAlternateKey(a => a.Account.Id);
            //entityBuilder.Property(x => x.AccountId).IsRequired();
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Phone).HasMaxLength(11);
            entityBuilder.Property(x => x.Mail).HasMaxLength(50);

        }
    }
}
