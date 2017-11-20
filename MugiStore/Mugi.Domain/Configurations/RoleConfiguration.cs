using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mugi.Domain.Entities;

namespace Mugi.Domain.Configurations
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(x => x.RoleName).IsRequired().HasMaxLength(10);
        }
    }
}
