using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

public class EmptyPermissionException : DomainException
{
    public EmptyPermissionException()
        : base("Empty permission.")
    {
    }
}