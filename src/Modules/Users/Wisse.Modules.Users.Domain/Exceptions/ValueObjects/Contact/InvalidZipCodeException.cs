using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Contact;

internal class InvalidZipCodeException : DomainException
{
    public InvalidZipCodeException()
        : base("Zip code is invalid.")
    {
    }
}