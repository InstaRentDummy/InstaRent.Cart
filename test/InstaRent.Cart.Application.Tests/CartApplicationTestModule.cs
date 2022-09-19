using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartDomainTestModule),
    typeof(CartApplicationModule)
    )]
public class CartApplicationTestModule : AbpModule
{

}
