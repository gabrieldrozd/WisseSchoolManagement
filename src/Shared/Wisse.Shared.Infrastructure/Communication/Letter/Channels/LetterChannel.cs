using System.Threading.Channels;
using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Letter.Channels;

internal sealed class LetterChannel : ILetterChannel
{
    private readonly Channel<ILetter> _messages = Channel.CreateUnbounded<ILetter>();

    public ChannelReader<ILetter> Reader => _messages.Reader;
    public ChannelWriter<ILetter> Writer => _messages.Writer;
}