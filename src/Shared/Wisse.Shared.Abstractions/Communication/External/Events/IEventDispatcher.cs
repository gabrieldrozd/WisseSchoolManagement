using Wisse.Common.Communication.External;

namespace Wisse.Shared.Abstractions.Communication.External.Events;

public interface IEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event)
        where TEvent : class, IEvent;
}