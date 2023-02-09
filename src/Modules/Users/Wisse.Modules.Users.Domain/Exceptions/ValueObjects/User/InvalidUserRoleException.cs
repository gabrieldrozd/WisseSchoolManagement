using Wisse.Common.Auth;
using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

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