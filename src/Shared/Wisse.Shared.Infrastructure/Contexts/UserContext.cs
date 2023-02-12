using System.IdentityModel.Tokens.Jwt;
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

    public void Populate(JwtSecurityToken securityToken)
    {
        UserId = securityToken.Claims
            .Where(x => x.Type == "userId")
            .Select(x => Guid.Parse(x.Value))
            .FirstOrDefault();
        Email = securityToken.Claims
            .Where(x => x.Type == "email")
            .Select(x => new Email(x.Value))
            .FirstOrDefault();
        Role = securityToken.Claims
            .Where(x => x.Type == "role")
            .Select(x => new Role(x.Value))
            .FirstOrDefault();

        var tokenPermissions = securityToken.Claims
            .FirstOrDefault(x => x.Type == "permissions")!.Value;
        var permissions = JsonConvert.DeserializeObject<List<string>>(tokenPermissions)
            .Select(x => new Permission(x));
        Permissions = permissions.ToList();
    }
}