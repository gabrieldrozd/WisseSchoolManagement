using Wisse.Common.Exceptions;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

internal class InvalidEnrollmentStatusException : DomainException
{
    public InvalidEnrollmentStatusException()
        : base($"""
Invalid enrollment status. Valid statuses are:
{Status.Pending}, {Status.Approved}, {Status.Rejected}.
""")
    {
    }
}