using Wisse.Base.Results;
using Wisse.Common.Communication.Internal;

namespace Wisse.Shared.Abstractions.Communication.Internal.Queries;

public interface IQueryDispatcher
{
    Task<Result<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}