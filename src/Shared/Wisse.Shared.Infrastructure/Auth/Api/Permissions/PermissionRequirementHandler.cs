using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Exceptions;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Auth.Api.Permissions;

public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserContext _userContext;

    public PermissionRequirementHandler(IUserContext userContext)
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
            throw new NotAllowedException();
        }

        return Task.CompletedTask;
    }
}