using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.Email;

internal class EmptyEmailException : DomainException
{
    public EmptyEmailException()
        : base("Email cannot be empty.")
    {
    }
}