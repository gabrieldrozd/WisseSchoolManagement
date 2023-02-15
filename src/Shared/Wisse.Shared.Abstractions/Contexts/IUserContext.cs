using Wisse.Common.Auth;
using Wisse.Common.Domain.ValueObjects;

namespace Wisse.Shared.Abstractions.Contexts;

public interface IUserContext
{
    public bool Authenticated { get; set; }
    public Date Expires { get; set; }
    public Guid UserId { get; set; }
    public Email Email { get; set; }
    public Role Role { get; set; }
    public List<Permission> Permissions { get; set; }

    /// <summary>
    /// Checks whether the user has the required permissions
    /// </summary>
    /// <param name="requiredPermissions">Required permissions</param>
    /// <returns>true -> User has permissions, false -> User has not permissions</returns>
    bool HasPermissions(PermissionKey[] requiredPermissions);

    bool IsInRole(RoleKey[] requiredRoles);
}