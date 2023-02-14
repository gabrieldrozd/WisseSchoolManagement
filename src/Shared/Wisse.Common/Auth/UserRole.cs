using Wisse.Base.Types;

namespace Wisse.Common.Auth;

public class UserRole : ObjectEnumeration<UserRole, RoleKey>
{
    public static readonly UserRole Admin = AdminRole();
    public static readonly UserRole Student = StudentRole();
    public static readonly UserRole Teacher = TeacherRole();

    private UserRole(RoleKey key) : base(key)
    {
    }

    public static UserRole TryGetRole(RoleKey key)
    {
        UserRole role;
        if (FromKey(key) is not null)
        {
            role = FromKey(key);
        }
        else
        {
            return null;
        }

        return role;
    }

    public static UserRole TryGetRole(string value)
    {
        UserRole role;
        if (FromKeyString(value) is not null)
        {
            role = FromKeyString(value);
        }

        else if (Enum.TryParse<RoleKey>(value, out var key) &&
                 FromKey(key) is not null)
        {
            role = FromKey(key);
        }
        else
        {
            return null;
        }

        return role;
    }

    private static UserRole FromKeyString(string key)
        => Enum.TryParse<RoleKey>(key, out var roleKey)
            ? FromKey(roleKey)
            : null;

    private static UserRole AdminRole() => new(RoleKey.Admin);
    private static UserRole StudentRole() => new(RoleKey.Student);
    private static UserRole TeacherRole() => new(RoleKey.Teacher);
}