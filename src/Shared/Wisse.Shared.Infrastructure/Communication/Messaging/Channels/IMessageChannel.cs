using System.Threading.Channels;
using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Messaging.Channels;

internal interface IMessageChannel
{
    ChannelReader<IMessage> Reader { get; }
    ChannelWriter<IMessage> Writer { get; }
}