using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant;

internal class EmptyEducationDetailsException : DomainException
{
    public EmptyEducationDetailsException()
        : base("Empty education details.")
    {
    }
}