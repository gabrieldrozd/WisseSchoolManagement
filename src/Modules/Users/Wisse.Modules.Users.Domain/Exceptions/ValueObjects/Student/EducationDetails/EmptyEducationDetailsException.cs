using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.EducationDetails;

internal class EmptyEducationDetailsException : DomainException
{
    public EmptyEducationDetailsException()
        : base("Empty education details.")
    {
    }
}