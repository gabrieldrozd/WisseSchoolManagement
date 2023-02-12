using Microsoft.AspNetCore.Http;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal sealed class Context : IContext
{
    public string RequestId { get; } = $"{Guid.NewGuid():N}";
    public string TraceId { get; }
    public IUserContext User { get; }

    internal Context()
    {
    }

    private Context(string traceId, IUserContext userContext)
    {
        TraceId = traceId;
        User = userContext;
    }

    public Context(HttpContext context)
        : this(context.TraceIdentifier, new UserContext(context))
    {
    }

    public static IContext Empty => new Context();
}
