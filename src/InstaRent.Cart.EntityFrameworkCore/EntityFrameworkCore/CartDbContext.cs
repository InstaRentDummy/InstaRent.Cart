using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Cart.EntityFrameworkCore;

[ConnectionStringName(CartDbProperties.ConnectionStringName)]
public class CartDbContext : AbpDbContext<CartDbContext>, ICartDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CartDbContext(DbContextOptions<CartDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCart();
    }
}
