using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Wisse.Base.Results.Core;
using Wisse.Common.Exceptions;
using Wisse.Common.Exceptions.Infrastructural;
using Wisse.Common.Models.Envelope;
using Wisse.Shared.Abstractions.Auth;

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
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = options.Issuer,
                    ValidAudience = options.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(options.IssuerSigningKey)),
                };
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = _ => throw new AuthorizationException()
                };
            });

        services.AddAuthorization();

        return services;
    }
}