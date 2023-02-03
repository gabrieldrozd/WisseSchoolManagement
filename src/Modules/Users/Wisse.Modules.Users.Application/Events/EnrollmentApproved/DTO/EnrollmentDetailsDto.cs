namespace Wisse.Modules.Users.Application.Events.EnrollmentApproved.DTO;

public class EnrollmentDetailsDto
{
    public Guid ExternalId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDetailsDto Applicant { get; set; }
    public ContactDetailsDto Contact { get; set; }
}