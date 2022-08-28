using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace InstaRent.Cart.MongoDB;

[ConnectionStringName(CartDbProperties.ConnectionStringName)]
public class CartMongoDbContext : AbpMongoDbContext, ICartMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCart();
    }
}
