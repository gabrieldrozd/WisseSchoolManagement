using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Exceptions.ValueObjects.Permission;

namespace Wisse.Common.Domain.ValueObjects;

public class Permission : ValueObject
{
    public PermissionKey Key { get; }

    private Permission()
    {
    }

    private Permission(PermissionKey key)
    {
        var permission = UserPermission.TryGetPermission(key);
        if (permission is null)
        {
            throw new InvalidPermissionException();
        }

        Key = permission.Key;
    }

    private Permission(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyPermissionException();
        }

        var permission = UserPermission.TryGetPermission(value);
        if (permission is null)
        {
            throw new InvalidPermissionException();
        }

        Key = permission.Key;
    }

    public static Permission Create(UserPermission permission)
        => new(permission.Key);

    public static Permission FromString(string permission)
        => new(permission);

    /// <summary>
    /// $"{Key}"
    /// </summary>
    public override string ToString() => $"{Key}";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
    }
}