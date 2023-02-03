using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.Phone;

internal class EmptyPhoneException : DomainException
{
    public EmptyPhoneException()
        : base("Phone cannot be empty.")
    {
    }
}