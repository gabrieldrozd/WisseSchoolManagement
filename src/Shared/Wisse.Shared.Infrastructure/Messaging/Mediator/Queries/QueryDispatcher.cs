using Microsoft.Extensions.DependencyInjection;
using Wisse.Base.Results;
using Wisse.Common.Messaging.Mediator;
using Wisse.Shared.Abstractions.Messaging.Mediator.Queries;

namespace Wisse.Shared.Infrastructure.Messaging.Mediator.Queries;

internal class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await ((Task<Result<TResult>>) handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
            ?.Invoke(handler, new object[] { query, cancellationToken }))!;
    }
}