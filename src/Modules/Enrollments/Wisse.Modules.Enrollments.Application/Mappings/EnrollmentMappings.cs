using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings;

public static class EnrollmentMappings
{
    public static EnrollmentDetailsDto ToEnrollmentDetailsDto(this Enrollment model)
        => new()
        {
            EnrollmentDate = model.EnrollmentDate.ToDateTime(),
            EnrollmentStatus = model.EnrollmentStatus.Value,
            Applicant = model.Applicant.ToApplicantDetailsDto(),
            Contact = model.Contact.ToContactDetailsDto(),
        };

    public static EnrollmentDto ToEnrollmentDto(this Enrollment model)
        => new()
        {
            EnrollmentDate = model.EnrollmentDate.ToDateTime(),
            EnrollmentStatus = model.EnrollmentStatus.Value,
            Applicant = model.Applicant.ToApplicantDto(),
            Contact = model.Contact.ToContactDto(),
        };
}