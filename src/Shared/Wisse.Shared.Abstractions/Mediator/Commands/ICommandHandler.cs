using Wisse.Common.Results;
using Wisse.Common.Utilities.Messaging.Mediator;

namespace Wisse.Shared.Abstractions.Mediator.Commands;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}