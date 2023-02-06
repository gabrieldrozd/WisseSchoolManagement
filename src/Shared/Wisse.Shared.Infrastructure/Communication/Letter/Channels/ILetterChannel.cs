using System.Threading.Channels;
using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Letter.Channels;

internal interface ILetterChannel
{
    ChannelReader<ILetter> Reader { get; }
    ChannelWriter<ILetter> Writer { get; }
}