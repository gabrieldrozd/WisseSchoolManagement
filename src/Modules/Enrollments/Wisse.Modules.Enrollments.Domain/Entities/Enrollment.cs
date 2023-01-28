using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Enrollment : AggregateRoot
{
    public Date EnrollmentDate { get; private set; }
    public EnrollmentStatus EnrollmentStatus { get; private set; }
    public Applicant Applicant { get; set; }
    public Contact Contact { get; set; }

    private Enrollment(Guid id)
        : base(id)
    {
    }

    private Enrollment(Guid id, Date enrollmentDate, EnrollmentStatus enrollmentStatus)
        : this(id)
    {
        EnrollmentDate = enrollmentDate;
        EnrollmentStatus = enrollmentStatus;
    }

    public static Enrollment Create(Guid id, DateTime enrollmentDate)
    {
        var date = new Date(enrollmentDate);
        var status = EnrollmentStatus.Create(Status.Pending);
        return new Enrollment(id, date, status);
    }

    public Enrollment SetApplicant(Applicant applicant)
    {
        Applicant = applicant;
        return this;
    }

    public Enrollment SetContact(Contact contact)
    {
        Contact = contact;
        return this;
    }
}