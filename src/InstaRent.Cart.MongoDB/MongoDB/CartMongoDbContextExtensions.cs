using Volo.Abp;
using Volo.Abp.MongoDB;

namespace InstaRent.Cart.MongoDB;

public static class CartMongoDbContextExtensions
{
    public static void ConfigureCart(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
