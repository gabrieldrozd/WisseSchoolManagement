using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Middleware;

internal class UserContextMiddleware : IMiddleware
{
    private readonly IUserContext _userContext;

    public UserContextMiddleware(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
        {
            await next(context);
            return;
        }

        var handler = new JwtSecurityTokenHandler();
        if (handler.ReadToken(token) is not JwtSecurityToken securityToken)
        {
            await next(context);
            return;
        }

        _userContext.Populate(securityToken);
        await next(context);
    }
}
