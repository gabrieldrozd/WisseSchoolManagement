using Wisse.Modules.Enrollments.Application.DTO.Applicant.Response;
using Wisse.Modules.Enrollments.Application.DTO.Contact;

namespace Wisse.Modules.Enrollments.Application.DTO.Enrollment;

public class EnrollmentDetailsDto
{
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
    public ApplicantDetailsDto Applicant { get; set; }
    public ContactDetailsDto Contact { get; set; }
}