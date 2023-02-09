using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

internal class EmptyUserRoleException : DomainException
{
    public EmptyUserRoleException()
        : base("User role cannot be empty.")
    {
    }
}