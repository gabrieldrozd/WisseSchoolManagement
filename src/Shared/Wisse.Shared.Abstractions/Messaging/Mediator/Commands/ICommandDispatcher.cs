using Wisse.Base.Results;
using Wisse.Common.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Messaging.Mediator.Commands;

public interface ICommandDispatcher
{
    Task<Result> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}