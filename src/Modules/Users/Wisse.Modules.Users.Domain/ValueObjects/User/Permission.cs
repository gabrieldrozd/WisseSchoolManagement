using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.ValueObjects.User;

// TODO: Decide whether it is good to have Permission ValueObject in UsersModule or in Common
// TODO: Decide whether it is good to have Permission ValueObject in UsersModule or in Common
// TODO: Decide whether it is good to have Permission ValueObject in UsersModule or in Common

// /\/\ -> Probably it is better to have it in Common
public class Permission : ValueObject
{
    public string Key { get; }
    public string Name { get; }

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

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
        yield return Name;
    }
}