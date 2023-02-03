using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

internal class EmptyLastNameException : DomainException
{
    public EmptyLastNameException()
        : base("Last name cannot be empty.")
    {
    }
}