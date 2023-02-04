namespace Wisse.Common.Domain.Users;

public static class Roles
{
    public static class AdminRole
    {
        public const string Name = "Admin";
        public const string NameNormalized = "ADMIN";
    }

    public static class StudentRole
    {
        public const string Name = "Student";
        public const string NameNormalized = "STUDENT";
    }

    public static class TeacherRole
    {
        public const string Name = "Teacher";
        public const string NameNormalized = "TEACHER";
    }
}
