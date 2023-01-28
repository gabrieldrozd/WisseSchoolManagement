using MediatR;
using Wisse.Common.Results;

namespace Wisse.Shared.Abstractions.Mediator.Query;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, DataResult<TResponse>>
    where TQuery : IQuery<TResponse>
{
}