using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

internal class EmptyEnrollmentStatusException : DomainException
{
    public EmptyEnrollmentStatusException()
        : base("Empty enrollment status.")
    {
    }
}