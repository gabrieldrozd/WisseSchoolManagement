using MediatR;
using Wisse.Common.Results;

namespace Wisse.Shared.Abstractions.Mediator.Command;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand<TResponse>
{
}