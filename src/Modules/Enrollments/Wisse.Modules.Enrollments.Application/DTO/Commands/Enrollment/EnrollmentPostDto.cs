using Wisse.Modules.Enrollments.Application.DTO.Commands.Applicant;
using Wisse.Modules.Enrollments.Application.DTO.Commands.Contact;

namespace Wisse.Modules.Enrollments.Application.DTO.Commands.Enrollment;

public class EnrollmentPostDto
{
    public Guid Id { get; } = Guid.NewGuid();
    public ApplicantPostDto Applicant { get; set; }
    public ContactPostDto Contact { get; set; }
}