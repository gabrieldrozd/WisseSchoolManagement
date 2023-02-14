using Microsoft.AspNetCore.Authorization;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Auth.Api.Roles;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
{
    private readonly IUserContext _userContext;

    public RoleAuthorizationHandler(IUserContext userContext)
    {
        _userContext = userContext;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        RoleRequirement requirement)
    {
        var hasPermissions = _userContext.IsInRole(requirement.Roles);
        if (hasPermissions)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}