using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Exceptions.ValueObjects.Role;

namespace Wisse.Common.Domain.ValueObjects;

public class Role : ValueObject
{
    public RoleKey Key { get; }

    private Role(RoleKey key)
    {
        var role = UserRole.TryGetRole(key);
        if (role is null)
        {
            throw new InvalidUserRoleException();
        }

        Key = role.Key;
    }

    private Role(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyUserRoleException();
        }

        var role = UserRole.TryGetRole(value);
        if (role is null)
        {
            throw new InvalidUserRoleException();
        }

        Key = role.Key;
    }

    public static Role Create(UserRole userRole)
        => new(userRole.Key);

    public static Role FromString(string role)
        => new(role);

    /// <summary>
    /// $"{Key}"
    /// </summary>
    public override string ToString() => $"{Key}";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
    }
}
