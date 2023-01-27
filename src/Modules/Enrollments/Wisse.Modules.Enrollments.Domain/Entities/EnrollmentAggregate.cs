namespace Wisse.Modules.Enrollments.Domain.Entities;

public class EnrollmentAggregate
{
    public Enrollment Enrollment { get; private set; }
    public Applicant Applicant { get; private set; }
    public Contact Contact { get; private set; }
}
