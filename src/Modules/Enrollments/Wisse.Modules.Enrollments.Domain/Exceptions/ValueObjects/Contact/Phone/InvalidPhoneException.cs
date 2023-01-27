using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.Phone;

public class InvalidPhoneException : DomainException
{
    public InvalidPhoneException()
        : base("Phone is invalid.")
    {
    }
}