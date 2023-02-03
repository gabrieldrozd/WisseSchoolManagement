using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Contact;

internal class EmptyZipCodeException : DomainException
{
    public EmptyZipCodeException()
        : base("Zip code cannot be empty.")
    {
    }
}