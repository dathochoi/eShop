using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eShopData.EF
{
    public class EShopDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        public EShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            
            .AddJsonFile("appsettings.json")
            .Build();

            var conectionString = configuration.GetConnectionString("eShopDb");

            var optionsBuider = new DbContextOptionsBuilder<EShopDbContext>();
            optionsBuider.UseSqlServer(conectionString);

            return new EShopDbContext(optionsBuider.Options);
        }

    }
}
