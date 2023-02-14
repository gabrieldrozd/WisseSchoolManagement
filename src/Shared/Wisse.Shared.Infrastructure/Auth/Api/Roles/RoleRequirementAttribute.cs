using Microsoft.AspNetCore.Authorization;
using Wisse.Common.Auth;

namespace Wisse.Shared.Infrastructure.Auth.Api.Roles;

public class RoleRequirementAttribute : AuthorizeAttribute
{
    public new RoleKey[] Roles { get; }

    public RoleRequirementAttribute(RoleKey role)
        : base($"{PolicyPrefix.Roles}:{role.ToString()}")
    {
        Roles = new[] { role };
    }

    public RoleRequirementAttribute(params RoleKey[] roles)
        : base(roles.Any() ? $"{PolicyPrefix.Roles}:{string.Join(";", roles)}" : string.Empty)
    {
        Roles = roles;
    }
}