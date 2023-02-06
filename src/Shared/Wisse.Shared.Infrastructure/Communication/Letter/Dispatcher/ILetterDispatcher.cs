using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Letter.Dispatcher;

internal interface ILetterDispatcher
{
    Task PublishAsync<TLetter>(TLetter message)
        where TLetter : class, ILetter;
}