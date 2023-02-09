using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.ValueObjects.User;
using UserRole = Wisse.Common.Auth.UserRole;

namespace Wisse.Modules.Users.Domain.Entities.Users.Base;

public abstract class User : AggregateRoot
{
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public bool IsActive { get; set; }

    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }

    #region Foreign

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    #endregion

    protected User(Guid externalId) : base(externalId)
    {
    }

    protected User(Guid externalId, string passwordHash, UserRole userRole, UserDefinition definition)
        : base(externalId)
    {
        PasswordHash = passwordHash;
        Role = Role.Create(userRole);
        Email = definition.Email;
        PhoneNumber = definition.PhoneNumber;
        FirstName = new FirstName(definition.FirstName);
        LastName = new LastName(definition.LastName);
        IsActive = true;

        SecurityStamp = Guid.NewGuid().ToString();
        ConcurrencyStamp = Guid.NewGuid().ToString();

        AddPermissions(UserPermission.StudentPermissions);
    }

    public void AddPermission(UserPermission permission)
    {
        var permissionToAdd = Permission.Create(permission);
        if (Permissions.Contains(permissionToAdd))
        {
            return;
        }

        Permissions.Add(permissionToAdd);
    }

    public void AddPermissions(IEnumerable<UserPermission> permissions)
    {
        foreach (var permission in permissions)
            AddPermission(permission);
    }

    public void RemovePermission(UserPermission permission)
    {
        var permissionToRemove = Permission.Create(permission);
        if (!Permissions.Contains(permissionToRemove))
        {
            return;
        }

        Permissions.Remove(permissionToRemove);
    }

    // TODO: Fix remaining errors in application
    // TODO: Fix remaining errors in application
    // TODO: Fix remaining errors in application
    // TODO: Fix remaining errors in application
    // TODO: Fix remaining errors in application
}