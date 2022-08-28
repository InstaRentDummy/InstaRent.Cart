using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Cart.EntityFrameworkCore;

public class CartHttpApiHostMigrationsDbContext : AbpDbContext<CartHttpApiHostMigrationsDbContext>
{
    public CartHttpApiHostMigrationsDbContext(DbContextOptions<CartHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCart();
    }
}
