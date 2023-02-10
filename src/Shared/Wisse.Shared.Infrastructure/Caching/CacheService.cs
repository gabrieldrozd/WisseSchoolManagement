using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Wisse.Base.Results;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Shared.Abstractions.Caching;

namespace Wisse.Shared.Infrastructure.Caching;

internal sealed class CacheService : ICacheService
{
    private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();

    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _distributedCacheOptions = new()
    {
        AbsoluteExpiration = Date.Now.AddMinutes(5)
    };

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<Result<T>> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var cachedData = await _distributedCache.GetStringAsync(key, cancellationToken);
        if (string.IsNullOrWhiteSpace(cachedData))
        {
            return Result.NotFound<T>(typeof(T).Name);
        }

        var deserialized = JsonConvert.DeserializeObject<T>(
            cachedData,
            new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        return Result.Success(deserialized);
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
    {
        var data = JsonConvert.SerializeObject(value);
        await _distributedCache.SetStringAsync(key, data, _distributedCacheOptions, cancellationToken);
        CacheKeys.TryAdd(key, true);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(key, cancellationToken);
        CacheKeys.TryRemove(key, out _);
    }

    public async Task InvalidateEntries(string entityName, CancellationToken cancellationToken = default)
    {
        var tasks = CacheKeys.Keys
            .Where(key => key.StartsWith(entityName))
            .Select(key => RemoveAsync(key, cancellationToken));

        await Task.WhenAll(tasks);
    }
}