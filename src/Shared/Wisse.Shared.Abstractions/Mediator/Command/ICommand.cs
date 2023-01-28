using MediatR;
using Wisse.Common.Results;

namespace Wisse.Shared.Abstractions.Mediator.Command;

public interface ICommand<TResponse> : IRequest<Result>
{
}