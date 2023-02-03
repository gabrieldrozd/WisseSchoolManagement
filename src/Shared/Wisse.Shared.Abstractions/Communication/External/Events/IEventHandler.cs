using Wisse.Common.Communication.External;

namespace Wisse.Shared.Abstractions.Communication.External.Events;

public interface IEventHandler<in TEvent>
    where TEvent : class, IEvent
{
    Task HandleAsync(TEvent @event);
}