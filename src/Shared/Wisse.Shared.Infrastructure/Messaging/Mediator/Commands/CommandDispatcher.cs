using Microsoft.Extensions.DependencyInjection;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Common.Messaging.Mediator;
using Wisse.Shared.Abstractions.Messaging.Mediator.Commands;

namespace Wisse.Shared.Infrastructure.Messaging.Mediator.Commands;

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
            return Result.Failure(Failure.MediatorFailure);
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        return await handler.HandleAsync(command, cancellationToken);
    }
}
