using System.Collections.Concurrent;
using Humanizer;
using Wisse.Base.Results.Core;
using Wisse.Common.Exceptions;
using Wisse.Common.Models.Envelope;
using Wisse.Shared.Abstractions.Exceptions;

namespace Wisse.Shared.Infrastructure.Middleware.Exceptions;

internal sealed class ExceptionMapper : IExceptionMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();

    public Envelope Map(System.Exception exception)
        => exception switch
        {
            DomainException ex => new Envelope(false, new Error(GetErrorCode(ex), ex.Message)).WithCode(400),
            AuthException ex => new Envelope(false, new Error(GetErrorCode(ex), ex.Message)).WithCode(401),
            NotFoundException ex => new Envelope(false, new Error(GetErrorCode(ex), ex.Message)).WithCode(404),
            _ => new Envelope(false, Error.Unexpected()).WithCode(500)
        };

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return Codes.GetOrAdd(type, type.Name.Pascalize().Replace("Exception", string.Empty));
    }
}
