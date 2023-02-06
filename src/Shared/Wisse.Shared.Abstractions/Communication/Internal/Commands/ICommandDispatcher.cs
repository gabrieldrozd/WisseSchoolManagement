using Wisse.Base.Results;
using Wisse.Common.Communication.Internal;

namespace Wisse.Shared.Abstractions.Communication.Internal.Commands;

public interface ICommandDispatcher
{
    Task<Result> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;

    Task<Result<TResult>> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
        where TResult : class;
}