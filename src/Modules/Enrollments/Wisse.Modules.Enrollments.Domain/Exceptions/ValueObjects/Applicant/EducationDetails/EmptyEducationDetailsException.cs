using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.EducationDetails;

internal class EmptyEducationDetailsException : DomainException
{
    public EmptyEducationDetailsException()
        : base("Empty education details.")
    {
    }
}