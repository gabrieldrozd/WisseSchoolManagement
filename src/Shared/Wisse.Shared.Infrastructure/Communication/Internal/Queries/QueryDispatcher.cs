using Microsoft.Extensions.DependencyInjection;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Common.Communication.Internal;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Shared.Infrastructure.Communication.Internal.Queries;

internal class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        if (query is null)
        {
            return Result.Failure<TResult>(Failure.Mediator);
        }

        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await ((Task<Result<TResult>>) handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
            ?.Invoke(handler, new object[] { query, cancellationToken }))!;
    }
}