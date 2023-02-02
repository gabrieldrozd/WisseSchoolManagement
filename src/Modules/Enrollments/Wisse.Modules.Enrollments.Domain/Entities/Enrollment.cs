using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Enrollment : AggregateRoot
{
    public Date EnrollmentDate { get; private set; }
    public EnrollmentStatus EnrollmentStatus { get; private set; }
    public Applicant Applicant { get; set; }
    public Contact Contact { get; set; }

    private Enrollment(Guid externalId)
        : base(externalId)
    {
    }

    private Enrollment(Guid externalId, Date enrollmentDate, EnrollmentStatus enrollmentStatus)
        : this(externalId)
    {
        EnrollmentDate = enrollmentDate;
        EnrollmentStatus = enrollmentStatus;
    }

    public static Enrollment Create(Guid id, Date enrollmentDate)
    {
        var status = EnrollmentStatus.Pending();
        return new Enrollment(id, enrollmentDate, status);
    }

    public void SetApplicant(Applicant applicant)
        => Applicant = applicant;

    public void SetContact(Contact contact)
        => Contact = contact;

    public void Approve()
    {
        if (EnrollmentStatus.Equals(EnrollmentStatus.Approved()))
        {
            throw new EnrollmentAlreadyApprovedException(ExternalId);
        }

        EnrollmentStatus = EnrollmentStatus.Approved();
    }

    public void Reject()
    {
        if (EnrollmentStatus.Equals(EnrollmentStatus.Rejected()))
        {
            throw new EnrollmentAlreadyRejectedException(ExternalId);
        }

        EnrollmentStatus = EnrollmentStatus.Rejected();
    }
}