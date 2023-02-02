using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

internal class EnrollmentAlreadyApprovedException : DomainException
{
    public EnrollmentAlreadyApprovedException(Guid externalId)
        : base($"Enrollment with Id: '{externalId:D}' is already approved.")
    {
    }
}