using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Wisse.Shared.Abstractions.Auth;
using Wisse.Shared.Infrastructure.Auth.Api;
using Wisse.Shared.Infrastructure.Auth.Api.Authenticated;
using Wisse.Shared.Infrastructure.Auth.Api.Permissions;
using Wisse.Shared.Infrastructure.Auth.Api.Roles;

namespace Wisse.Shared.Infrastructure.Auth;

internal static class Extensions
{
    private const string SectionName = "Auth";

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        var options = services.GetOptions<AuthOptions>(SectionName);
        services.AddSingleton(options);

        services.AddSingleton<ITokenProvider, TokenProvider>();

        services
            .AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = options.Issuer,
                    ValidAudience = options.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(options.IssuerSigningKey)),
                };
            });

        services.AddAuthorization();
        services.AddSingleton<IAuthorizationHandler, AuthenticatedRequirementHandler>();
        services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
        services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();

        return services;
    }
}