using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Auth;

namespace Wisse.Shared.Infrastructure.Auth.Api.Permissions;

public class PermissionRequirementAttribute : AuthorizeAttribute
{
    public PermissionKey[] Permissions { get; }

    public PermissionRequirementAttribute(PermissionKey permission)
        : base($"{PolicyPrefix.Permissions}:{permission.ToString()}")
    {
        Permissions = new[] { permission };
    }

    public PermissionRequirementAttribute(params PermissionKey[] permissions)
        : base(permissions.Any() ? $"{PolicyPrefix.Permissions}:{string.Join(";", permissions)}" : string.Empty)
    {
        Permissions = permissions;
    }
}