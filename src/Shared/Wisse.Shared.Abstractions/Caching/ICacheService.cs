using Wisse.Base.Results;

namespace Wisse.Shared.Abstractions.Caching;

public interface ICacheService
{
    Task<Result<T>> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default);
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    Task InvalidateEntries(string entityName, CancellationToken cancellationToken = default);
}