using Wisse.Common.Auth;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.ValueObjects.User;

public class Role : ValueObject
{
    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyUserRoleException();
        }

        if (UserRole.FromName(value) is null)
        {
            throw new InvalidUserRoleException(value);
        }

        Value = value;
    }

    public static Role Create(UserRole userRole)
        => new(userRole.Name);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
