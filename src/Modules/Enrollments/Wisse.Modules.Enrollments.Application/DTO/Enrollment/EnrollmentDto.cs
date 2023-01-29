using Wisse.Modules.Enrollments.Application.DTO.Contact;

namespace Wisse.Modules.Enrollments.Application.DTO.Enrollment;

public class EnrollmentDto
{
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDto Applicant { get; set; }
    public ContactDto Contact { get; set; }
}