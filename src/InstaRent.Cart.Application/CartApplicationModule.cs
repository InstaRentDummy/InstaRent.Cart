using InstaRent.Cart.Baskets;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartDomainModule),
    typeof(CartApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class CartApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        context.Services.AddAutoMapperObjectMapper<CartApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CartApplicationModule>(validate: true);
        });
        ConfigureDistributedCache(configuration);
    }

    private void ConfigureDistributedCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.CacheConfigurators.Add(cacheName =>
            {
                if (cacheName == CacheNameAttribute.GetCacheName(typeof(Basket)))
                {
                    return new DistributedCacheEntryOptions
                    {
                        //SlidingExpiration = TimeSpan.FromDays(7)
                        SlidingExpiration = TimeSpan.FromDays(Convert.ToDouble(configuration["Redis:Expiration"]))
                    };
                }

                return null;
            });
        });
    }
}
