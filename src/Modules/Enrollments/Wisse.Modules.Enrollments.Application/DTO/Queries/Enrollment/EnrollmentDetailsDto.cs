using Wisse.Modules.Enrollments.Application.DTO.Queries.Applicant;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Contact;

namespace Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

public class EnrollmentDetailsDto
{
    public Guid ExternalId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDetailsDto Applicant { get; set; }
    public ContactDetailsDto Contact { get; set; }
}