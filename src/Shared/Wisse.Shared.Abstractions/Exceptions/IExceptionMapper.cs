using Wisse.Common.Models.Envelope;

namespace Wisse.Shared.Abstractions.Exceptions;

public interface IExceptionMapper
{
    Envelope Map(Exception exception);
}