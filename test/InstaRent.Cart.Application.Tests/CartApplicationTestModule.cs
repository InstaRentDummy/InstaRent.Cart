using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartTestBaseModule),
    typeof(CartApplicationModule)
    )]
public class CartApplicationTestModule : AbpModule
{

}
