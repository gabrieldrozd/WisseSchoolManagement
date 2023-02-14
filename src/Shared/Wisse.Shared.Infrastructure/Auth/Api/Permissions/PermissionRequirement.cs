using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Auth;

namespace Wisse.Shared.Infrastructure.Auth.Api.Permissions;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionKey[] Permissions { get; }

    public PermissionRequirement(string permissions)
    {
        if (string.IsNullOrWhiteSpace(permissions))
        {
            Permissions = Array.Empty<PermissionKey>();
            return;
        }

        Permissions = permissions.Contains(';')
            ? permissions.Split(';').Select(Enum.Parse<PermissionKey>).ToArray()
            : new[] { Enum.Parse<PermissionKey>(permissions) };
    }
}