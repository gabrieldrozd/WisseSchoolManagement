using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Wisse.Shared.Infrastructure.Auth.Api.Permissions;
using Wisse.Shared.Infrastructure.Auth.Api.Roles;

namespace Wisse.Shared.Infrastructure.Auth.Api;

internal class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy is not null)
        {
            return policy;
        }

        var policyNamePrefix = policyName.Split(':')[0];
        if (policyNamePrefix != PolicyPrefix.Permissions && policyNamePrefix != PolicyPrefix.Roles)
        {
            return null;
        }

        return policyName.StartsWith(PolicyPrefix.Permissions)
            ? CreatePermissionPolicy(policyName)
            : CreateRolePolicy(policyName);
    }

    private static AuthorizationPolicy CreatePermissionPolicy(string policyName)
    {
        var permissions = policyName.Replace($"{PolicyPrefix.Permissions}:", string.Empty);
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(permissions))
            .Build();
    }

    private static AuthorizationPolicy CreateRolePolicy(string policyName)
    {
        var roles = policyName.Replace($"{PolicyPrefix.Roles}:", string.Empty);
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new RoleRequirement(roles))
            .Build();
    }
}