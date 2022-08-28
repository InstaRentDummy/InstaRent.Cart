using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CartHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CartConsoleApiClientModule : AbpModule
{

}
