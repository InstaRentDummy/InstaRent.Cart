using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Cart.EntityFrameworkCore;

[ConnectionStringName(CartDbProperties.ConnectionStringName)]
public interface ICartDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
