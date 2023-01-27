using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact;

public class EmptyEmailException : DomainException
{
    public EmptyEmailException()
        : base("Email cannot be empty.")
    {
    }
}