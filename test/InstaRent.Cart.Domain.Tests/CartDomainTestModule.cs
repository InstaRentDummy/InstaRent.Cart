 
using Volo.Abp.Modularity;

namespace InstaRent.Cart;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CartTestBaseModule)
    )]
public class CartDomainTestModule : AbpModule
{

}
