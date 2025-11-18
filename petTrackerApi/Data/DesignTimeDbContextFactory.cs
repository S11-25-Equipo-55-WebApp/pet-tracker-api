using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace petTrackerApi.Data
{
    public class DesignTimeDbContextFactory
    {
        public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
        {
            public DBContext CreateDbContext(string[] args)
            {
                // Ubicación del proyecto donde corre EF
                var basePath = Directory.GetCurrentDirectory();

                // Cargar configuración
                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

                return new DBContext(optionsBuilder.Options);
            }
        }
    }
}
