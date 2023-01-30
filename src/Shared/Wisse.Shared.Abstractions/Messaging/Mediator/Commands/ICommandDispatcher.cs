using Wisse.Common.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Messaging.Mediator.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}