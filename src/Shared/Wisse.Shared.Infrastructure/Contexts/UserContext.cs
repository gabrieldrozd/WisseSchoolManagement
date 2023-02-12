using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal class UserContext : IUserContext
{
    public Guid UserId { get; set; }
    public Email Email { get; set; }
    public Role Role { get; set; }
    public List<Permission> Permissions { get; set; }

    private UserContext()
    {
    }

    public UserContext(HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var securityToken =  new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        Populate(securityToken?.Claims);
    }

    public static IUserContext Empty => new UserContext();

    private void Populate(IEnumerable<Claim> claims)
    {
        claims = claims.ToList();

        UserId = claims
            .Where(x => x.Type == "userId")
            .Select(x => Guid.Parse(x.Value))
            .FirstOrDefault();
        Email = claims
            .Where(x => x.Type == "email")
            .Select(x => new Email(x.Value))
            .FirstOrDefault();
        Role = claims
            .Where(x => x.Type == "role")
            .Select(x => new Role(x.Value))
            .FirstOrDefault();

        var tokenPermissions = claims
            .FirstOrDefault(x => x.Type == "permissions")!.Value;
        var permissions = JsonConvert.DeserializeObject<List<string>>(tokenPermissions)
            .Select(x => new Permission(x));
        Permissions = permissions.ToList();
    }
}