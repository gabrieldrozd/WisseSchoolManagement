using MediatR;
using Wisse.Common.Results;

namespace Wisse.Shared.Abstractions.Mediator.Query;

public interface IQuery<TResponse> : IRequest<DataResult<TResponse>>
{
}