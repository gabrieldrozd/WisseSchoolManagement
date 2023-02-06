namespace Wisse.Contracts.Enrollments.Approved.Contracts;

public class EnrollmentDetailsContract
{
    public Guid ExternalId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDetailsContract Applicant { get; set; }
    public ContactDetailsContract Contact { get; set; }
}