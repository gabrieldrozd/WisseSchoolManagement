using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

public class InvalidPermissionException : DomainException
{
    public InvalidPermissionException()
        : base("Invalid permission.")
    {
    }
}
