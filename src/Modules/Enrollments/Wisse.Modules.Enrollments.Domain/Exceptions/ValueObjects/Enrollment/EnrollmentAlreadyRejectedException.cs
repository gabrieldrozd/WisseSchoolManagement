using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

internal class EnrollmentAlreadyRejectedException : DomainException
{
    public EnrollmentAlreadyRejectedException(Guid externalId)
        : base($"Enrollment with Id: '{externalId:D}' is already rejected.")
    {
    }
}