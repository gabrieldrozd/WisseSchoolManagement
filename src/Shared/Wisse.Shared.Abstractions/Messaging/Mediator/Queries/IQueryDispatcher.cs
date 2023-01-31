using Wisse.Base.Results;
using Wisse.Common.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Messaging.Mediator.Queries;

public interface IQueryDispatcher
{
    Task<Result<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}