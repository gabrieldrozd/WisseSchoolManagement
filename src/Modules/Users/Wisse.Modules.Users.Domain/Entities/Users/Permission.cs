using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User.Permission;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class Permission : ValueObject
{
    public string Key { get; }
    public string Name { get; }

    private Permission()
    {
    }

    public Permission(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPermissionException();
        }

        var permission = UserPermission.TryGetPermission(value);
        if (permission is null)
        {
            throw new InvalidPermissionException();
        }

        Key = permission.Key;
        Name = permission.Name;
    }

    public static Permission Create(UserPermission permission)
        => new(permission.Key);

    public static Permission FromString(string permission)
        => new(permission.Split("-")[0]);

    public override string ToString() => $"{Key}-{Name}";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
        yield return Name;
    }

    public int GetHashCode(Permission obj)
    {
        return HashCode.Combine(obj.Key, obj.Name);
    }
}