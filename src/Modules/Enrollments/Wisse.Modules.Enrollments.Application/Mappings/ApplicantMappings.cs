using Wisse.Modules.Enrollments.Application.DTO.Applicant;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings;

public static class ApplicantMappings
{
    public static ApplicantDetailsDto ToApplicantDetailsDto(this Applicant model)
    {
        return new ApplicantDetailsDto
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate.ToDateTime(),
            Education = new EducationDto
            {
                School = model.EducationDetails.School,
                Grade = model.EducationDetails.Grade,
            },
            LanguageLevel = new LanguageLevelDto
            {
                Key = model.LanguageLevel.Key,
                Name = model.LanguageLevel.Name
            }
        };
    }
}