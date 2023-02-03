using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.ZipCode;

internal class InvalidZipCodeException : DomainException
{
    public InvalidZipCodeException()
        : base("Zip code is invalid.")
    {
    }
}