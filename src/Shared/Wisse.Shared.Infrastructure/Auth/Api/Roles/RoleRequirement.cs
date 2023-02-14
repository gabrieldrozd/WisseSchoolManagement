using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Auth;

namespace Wisse.Shared.Infrastructure.Auth.Api.Roles;

public class RoleRequirement : IAuthorizationRequirement
{
    public RoleKey[] Roles { get; }

    public RoleRequirement(string roles)
    {
        if (string.IsNullOrWhiteSpace(roles))
        {
            Roles = Array.Empty<RoleKey>();
            return;
        }

        Roles = roles.Contains(';')
            ? roles.Split(';').Select(Enum.Parse<RoleKey>).ToArray()
            : new[] { Enum.Parse<RoleKey>(roles) };
    }
}