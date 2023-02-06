using MassTransit;
using Wisse.Common.Communication;
using Wisse.Shared.Abstractions.Messaging;

namespace Wisse.Shared.Infrastructure.Messaging;

internal sealed class MessageBus : IMessageBus
{
    private readonly IBus _bus;

    public MessageBus(IBus bus)
    {
        _bus = bus;
    }

    public async Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage
        => await _bus.Publish(message, cancellationToken);
}