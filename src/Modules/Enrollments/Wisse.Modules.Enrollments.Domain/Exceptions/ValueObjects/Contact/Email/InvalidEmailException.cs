using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.Email;

public class InvalidEmailException : DomainException
{
    public InvalidEmailException()
        : base("Email is invalid.")
    {
    }
}