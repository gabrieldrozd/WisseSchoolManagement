using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public abstract class User : AggregateRoot
{
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public bool IsActive { get; set; }
    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }
    public List<Permission> Permissions { get; set; } = new();

    protected User(Guid externalId) : base(externalId)
    {
    }

    protected User(Guid externalId, UserRole userRole, UserDefinition definition)
        : base(externalId)
    {
        Role = Role.Create(userRole);
        Email = new Email(definition.Email);
        PhoneNumber = new PhoneNumber(definition.PhoneNumber);
        FirstName = new FirstName(definition.FirstName);
        LastName = new LastName(definition.LastName);
        IsActive = true;

        SecurityStamp = Guid.NewGuid().ToString();
        ConcurrencyStamp = Guid.NewGuid().ToString();

        AddPermissions(UserPermission.StudentPermissions);
    }

    public void SetPasswordHash(string passwordHash)
        => PasswordHash = passwordHash;

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
}