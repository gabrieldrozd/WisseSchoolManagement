using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.ZipCode;

public class EmptyZipCodeException : DomainException
{
    public EmptyZipCodeException()
        : base("Zip code cannot be empty.")
    {
    }
}