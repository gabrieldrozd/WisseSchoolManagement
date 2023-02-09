using Wisse.Base.Types;

namespace Wisse.Common.Auth;

public class UserRole : Enumeration<UserRole>
{
    public static readonly UserRole Admin = AdminRole();
    public static readonly UserRole Student = StudentRole();
    public static readonly UserRole Teacher = TeacherRole();

    private UserRole(int value, string name) : base(value, name)
    {
    }

    private static UserRole AdminRole() => new(1, "Admin");
    private static UserRole StudentRole() => new(2, "Student");
    private static UserRole TeacherRole() => new(3, "Teacher");
}