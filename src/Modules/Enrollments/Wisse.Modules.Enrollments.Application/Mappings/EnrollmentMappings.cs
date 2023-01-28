using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings;

public static class EnrollmentMappings
{
    public static EnrollmentDetailsDto ToEnrollmentDetailsDto(this Enrollment model)
    {
        return new EnrollmentDetailsDto
        {
            EnrollmentDate = model.EnrollmentDate.ToDateTime(),
            EnrollmentStatus = model.EnrollmentStatus.Value,
            Applicant = model.Applicant.ToApplicantDetailsDto(),
            Contact = model.Contact.ToContactDetailsDto(),
        };
    }
}