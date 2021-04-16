using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace QuiltShop.Models
{
  public class QuiltShopContextFactory : IDesignTimeDbContextFactory<QuiltShopContext>
  {
    QuiltShopContext IDesignTimeDbContextFactory<QuiltShopContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
      
      var builder = new DbContextOptionsBuilder<QuiltShopContext>();
      string connectionString = configuration.GetConnectionString("Defaultconnection");

      builder.UseMySql(connectionString);

      return new QuiltShopContext(builder.Options);
    }
  }
}