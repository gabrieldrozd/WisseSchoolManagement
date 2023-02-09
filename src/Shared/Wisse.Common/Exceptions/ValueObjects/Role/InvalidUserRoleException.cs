using Wisse.Common.Auth;

namespace Wisse.Common.Exceptions.ValueObjects.Role;

internal class InvalidUserRoleException : DomainException
{
    public InvalidUserRoleException(string role)
        : base($"""
Invalid role '{role}'. Valid roles are:
{UserRole.Admin.Name},
{UserRole.Student.Name},
{UserRole.Teacher.Name}.
""")
    {
    }
}