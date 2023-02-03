using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

internal class EmptyFirstNameException : DomainException
{
    public EmptyFirstNameException()
        : base("First name cannot be empty.")
    {
    }
}