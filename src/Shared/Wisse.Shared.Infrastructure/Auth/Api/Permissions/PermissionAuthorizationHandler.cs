using Microsoft.AspNetCore.Authorization;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Auth.Api.Permissions;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserContext _userContext;

    public PermissionAuthorizationHandler(IUserContext userContext)
    {
        _userContext = userContext;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var hasPermissions = _userContext.HasPermissions(requirement.Permissions);
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