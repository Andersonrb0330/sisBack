
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class SisContextDesingTimeDbContextFactory : IDesignTimeDbContextFactory<SisContext>
    {
        public SisContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApiSis"))
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddJsonFile("appsettings.Development.json", optional: true)
                  .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SisContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlSis"));

            return new SisContext(optionsBuilder.Options);
        }
    }
}
