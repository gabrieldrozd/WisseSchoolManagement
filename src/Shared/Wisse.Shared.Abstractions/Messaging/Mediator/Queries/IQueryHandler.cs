using Wisse.Base.Results;
using Wisse.Common.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Messaging.Mediator.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery<TResult>
{
    Task<Result> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}