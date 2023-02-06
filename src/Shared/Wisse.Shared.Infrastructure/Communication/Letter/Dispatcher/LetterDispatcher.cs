using Wisse.Common.Communication;
using Wisse.Shared.Infrastructure.Communication.Letter.Channels;

namespace Wisse.Shared.Infrastructure.Communication.Letter.Dispatcher;

internal sealed class LetterDispatcher : ILetterDispatcher
{
    private readonly ILetterChannel _letterChannel;

    public LetterDispatcher(ILetterChannel letterChannel)
    {
        _letterChannel = letterChannel;
    }

    public async Task PublishAsync<TLetter>(TLetter message)
        where TLetter : class, ILetter
        => await _letterChannel.Writer.WriteAsync(message);
}