using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CartDomainSharedModule)
)]
public class CartDomainModule : AbpModule
{

}
