using Microsoft.Extensions.DependencyInjection;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Common.Communication.Internal;
using Wisse.Shared.Abstractions.Caching;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;
using Wisse.Shared.Infrastructure.Caching;

namespace Wisse.Shared.Infrastructure.Communication.Internal.Queries;

internal class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICacheService _cacheService;

    public QueryDispatcher(
        IServiceProvider serviceProvider,
        ICacheService cacheService)
    {
        _serviceProvider = serviceProvider;
        _cacheService = cacheService;
    }

    public async Task<Result<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        if (query is null)
        {
            return Result.Failure<TResult>(Failure.Mediator);
        }

        var cacheKey = query.BuildCacheKey();
        if (!NonCacheableKey.IsKeyCacheable(cacheKey))
        {
            var cachedResult = await _cacheService.GetAsync<TResult>(cacheKey, cancellationToken);
            if (cachedResult.IsSuccess)
            {
                return cachedResult;
            }
        }

        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        var response = await ((Task<Result<TResult>>) handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
            ?.Invoke(handler, new object[] { query, cancellationToken }))!;
        if (response.IsSuccess && !NonCacheableKey.IsKeyCacheable(cacheKey))
        {
            await _cacheService.SetAsync(cacheKey, response.Value, cancellationToken);
        }

        return response;
    }
}