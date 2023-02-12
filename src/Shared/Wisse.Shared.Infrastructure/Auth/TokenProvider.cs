using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Shared.Abstractions.Auth;
using Wisse.Shared.Abstractions.Utilities;

namespace Wisse.Shared.Infrastructure.Auth;

internal sealed class TokenProvider : ITokenProvider
{
    private readonly SigningCredentials _signingCredentials;
    private readonly AuthOptions _options;
    private readonly IClock _clock;

    public TokenProvider(AuthOptions options, IClock clock)
    {
        _signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.IssuerSigningKey)),
            SecurityAlgorithms.HmacSha256);

        _options = options;
        _clock = clock;
    }

    public AccessToken CreateToken(Guid userId, Email email, Role role, List<Permission> permissions)
    {
        var current = new Date(_clock.Current());
        var expires = new Date(_clock.Current().AddMinutes(_options.ExpiryInMinutes));

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("userId", userId.ToString()),
            new("email", email.Value),
            new("role", role.Value),
            new("permissions", JsonConvert.SerializeObject(permissions.Select(x => x.Key), Formatting.None)),
        };


        var token = new JwtSecurityToken(
            claims: claims,
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: expires.ToDateTime(),
            notBefore: current.ToDateTime(),
            signingCredentials: _signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        var accessToken = new AccessToken
        {
            Token = tokenValue,
            Expires = expires.ToUnixSeconds(),
            UserId = userId,
            Email = email.Value,
            Role = role.Value,
            Permissions = permissions.Select(x => x.Key).ToArray(),
        };

        return accessToken;
    }
}