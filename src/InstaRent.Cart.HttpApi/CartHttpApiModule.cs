using Localization.Resources.AbpUi;
using InstaRent.Cart.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CartHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CartHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CartResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
