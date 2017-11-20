using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Core
{
    public class MugiStoreDbContextFactory : IDesignTimeDbContextFactory<MugiStoreDbContext>
    {
        MugiStoreDbContext IDesignTimeDbContextFactory<MugiStoreDbContext>.CreateDbContext(string[] args)
        {
            var connectionString = @"Server=.;Database=MugiShop;Trusted_Connection=True;";
            var builder = new DbContextOptionsBuilder<MugiStoreDbContext>();
            builder.UseSqlServer(connectionString);

            return new MugiStoreDbContext(builder.Options);
        }
    }
}
