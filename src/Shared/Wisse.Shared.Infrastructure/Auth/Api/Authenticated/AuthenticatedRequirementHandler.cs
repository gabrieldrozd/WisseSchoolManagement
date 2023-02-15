using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Exceptions;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Auth.Api.Authenticated;

public class AuthenticatedRequirementHandler : AuthorizationHandler<AuthenticatedRequirement>
{
    private readonly IUserContext _userContext;

    public AuthenticatedRequirementHandler(IUserContext userContext)
    {
        _userContext = userContext;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        AuthenticatedRequirement requirement)
    {
        if (_userContext.Authenticated)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
            throw new NotAuthenticatedException();
        }

        return Task.CompletedTask;
    }
}