using Wisse.Common.Communication;
using Wisse.Shared.Infrastructure.Communication.Messaging.Channels;

namespace Wisse.Shared.Infrastructure.Communication.Messaging.Dispatcher;

internal sealed class MessageDispatcher : IMessageDispatcher
{
    private readonly IMessageChannel _messageChannel;

    public MessageDispatcher(IMessageChannel messageChannel)
    {
        _messageChannel = messageChannel;
    }

    public async Task PublishAsync<TMessage>(TMessage message)
        where TMessage : class, IMessage
        => await _messageChannel.Writer.WriteAsync(message);
}