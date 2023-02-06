using Wisse.Common.Communication;

namespace Wisse.Shared.Abstractions.Communication.Messaging;

public interface ILetterBroker
{
    Task PublishAsync(params ILetter[] messages);
}