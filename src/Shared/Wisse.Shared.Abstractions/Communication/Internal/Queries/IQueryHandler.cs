using Wisse.Base.Results;
using Wisse.Common.Communication.Internal;

namespace Wisse.Shared.Abstractions.Communication.Internal.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery<TResult>
{
    Task<Result<TResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}