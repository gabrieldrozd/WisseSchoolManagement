using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Caching;
using Wisse.Shared.Infrastructure.Caching.Models;

namespace Wisse.Shared.Infrastructure.Caching;

internal static class Extensions
{
    private const string SectionName = "redis";

    public static IServiceCollection AddCaching(this IServiceCollection services)
    {
        var redisConnection = services.GetOptions<RedisOptions>(SectionName);
        services.AddStackExchangeRedisCache(config => config.Configuration = redisConnection.ConnectionString);

        // services.AddDistributedMemoryCache();
        services.AddSingleton<ICacheService, CacheService>();
        return services;
    }
}
