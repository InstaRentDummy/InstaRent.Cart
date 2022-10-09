using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Modularity;

namespace InstaRent.Cart;

[DependsOn(
    typeof(CartDomainModule),
    typeof(CartApplicationContractsModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule)
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

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "InstaRent:";
        });

       // var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);

        //context.Services
        //    .AddDataProtection()
        //    .PersistKeysToStackExchangeRedis(redis, "InstaRent-Protection-Keys");

        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
    }

}
