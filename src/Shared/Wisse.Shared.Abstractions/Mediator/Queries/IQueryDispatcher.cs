using Wisse.Common.Results;
using Wisse.Common.Utilities.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Mediator.Queries;

public interface IQueryDispatcher
{
    Task<Result> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}