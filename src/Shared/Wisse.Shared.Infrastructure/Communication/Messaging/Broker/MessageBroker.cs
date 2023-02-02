using Wisse.Common.Communication;
using Wisse.Shared.Abstractions.Communication.Messaging;
using Wisse.Shared.Infrastructure.Communication.Messaging.Dispatcher;

namespace Wisse.Shared.Infrastructure.Communication.Messaging.Broker;

internal sealed class MessageBroker : IMessageBroker
{
    private readonly IMessageDispatcher _messageDispatcher;

    public MessageBroker(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }

    public async Task PublishAsync(params IMessage[] messages)
    {
        if (messages is null)
            return;

        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
            return;

        foreach (var message in messages)
            await _messageDispatcher.PublishAsync(message);
    }
}