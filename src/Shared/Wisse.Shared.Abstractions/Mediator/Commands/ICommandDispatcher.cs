using Wisse.Common.Utilities.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Mediator.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}