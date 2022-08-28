using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InstaRent.Cart.EntityFrameworkCore;

public class CartHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CartHttpApiHostMigrationsDbContext>
{
    public CartHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CartHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Cart"));

        return new CartHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
