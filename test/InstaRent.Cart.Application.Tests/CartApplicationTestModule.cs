using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartApplicationModule),
    typeof(CartDomainTestModule)
    )]
public class CartApplicationTestModule : AbpModule
{

}
