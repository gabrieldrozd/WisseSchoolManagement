using Wisse.Common.Auth;

namespace Wisse.Common.Exceptions.ValueObjects.Role;

internal class InvalidUserRoleException : DomainException
{
    public InvalidUserRoleException()
        : base($"""
Invalid role. Valid roles are:
{UserRole.Admin.Key},
{UserRole.Student.Key},
{UserRole.Teacher.Key}.
""")
    {
    }
}