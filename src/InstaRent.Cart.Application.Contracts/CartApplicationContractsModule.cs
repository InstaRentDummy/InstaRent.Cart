using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CartApplicationContractsModule : AbpModule
{

}
