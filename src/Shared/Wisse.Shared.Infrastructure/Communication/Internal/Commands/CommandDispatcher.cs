using Microsoft.Extensions.DependencyInjection;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Common.Communication.Internal;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Shared.Infrastructure.Communication.Internal.Commands;

internal sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
    {
        if (command is null)
        {
            return Result.Failure(Failure.Mediator);
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<Result<TResult>> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
        where TResult : class
    {
        if (command is null)
        {
            return Result.Failure<TResult>(Failure.Mediator);
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await handler.HandleAsync(command, cancellationToken);
    }
}
