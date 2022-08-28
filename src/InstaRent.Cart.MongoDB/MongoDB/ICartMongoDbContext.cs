using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace InstaRent.Cart.MongoDB;

[ConnectionStringName(CartDbProperties.ConnectionStringName)]
public interface ICartMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
