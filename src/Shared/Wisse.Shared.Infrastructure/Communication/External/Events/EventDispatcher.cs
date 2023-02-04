using Microsoft.Extensions.DependencyInjection;
using Wisse.Common.Communication.External;
using Wisse.Shared.Abstractions.Communication.External.Events;

namespace Wisse.Shared.Infrastructure.Communication.External.Events;

internal sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync<TEvent>(TEvent @event)
        where TEvent : class, IEvent
    {
        using var scope = _serviceProvider.CreateScope();
        var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

        var tasks = handlers.Select(handler => handler.HandleAsync(@event));
        await Task.WhenAll(tasks);
    }
}