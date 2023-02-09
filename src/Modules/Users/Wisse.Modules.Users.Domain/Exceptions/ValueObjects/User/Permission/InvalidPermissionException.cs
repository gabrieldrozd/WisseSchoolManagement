using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User.Permission;

public class InvalidPermissionException : DomainException
{
    public InvalidPermissionException()
        : base("Invalid permission.")
    {
    }
}
