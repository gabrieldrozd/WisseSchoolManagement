using Wisse.Common.Results;
using Wisse.Common.Utilities.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Mediator.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery<TResult>
{
    Task<Result> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}