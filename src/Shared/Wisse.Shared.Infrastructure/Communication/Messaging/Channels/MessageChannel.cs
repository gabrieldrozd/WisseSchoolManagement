using System.Threading.Channels;
using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Messaging.Channels;

internal sealed class MessageChannel : IMessageChannel
{
    private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

    public ChannelReader<IMessage> Reader => _messages.Reader;
    public ChannelWriter<IMessage> Writer => _messages.Writer;
}