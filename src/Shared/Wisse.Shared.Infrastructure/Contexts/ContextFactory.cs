using Microsoft.AspNetCore.Http;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal sealed class ContextFactory : IContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ContextFactory(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IContext Create()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        return httpContext is null
            ? Context.Empty
            : new Context(httpContext);
    }
}