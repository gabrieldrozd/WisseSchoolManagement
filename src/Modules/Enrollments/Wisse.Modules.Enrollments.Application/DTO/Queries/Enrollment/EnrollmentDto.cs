using Wisse.Modules.Enrollments.Application.DTO.Queries.Applicant;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Contact;

namespace Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

public class EnrollmentDto
{
    public Guid ExternalId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDto Applicant { get; set; }
    public ContactDto Contact { get; set; }
}