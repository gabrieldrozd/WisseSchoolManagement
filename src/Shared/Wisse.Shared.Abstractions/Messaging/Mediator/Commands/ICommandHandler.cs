using Wisse.Base.Results;
using Wisse.Common.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Messaging.Mediator.Commands;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}