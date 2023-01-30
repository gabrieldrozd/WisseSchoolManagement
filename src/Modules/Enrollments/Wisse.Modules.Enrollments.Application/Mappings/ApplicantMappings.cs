using Wisse.Modules.Enrollments.Application.DTO.Commands.Applicant;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Applicant;
using Wisse.Modules.Enrollments.Domain.Definitions;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings;

public static class ApplicantMappings
{
    public static ApplicantDetailsDto ToApplicantDetailsDto(this Applicant model)
        => new()
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

    public static ApplicantDto ToApplicantDto(this Applicant model)
        => new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate.ToDateTime(),
        };

    public static ApplicantDefinition ToDefinition(this ApplicantPostDto dto)
        => new()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate,
            School = dto.School,
            Grade = dto.Grade,
            LevelKey = dto.LevelKey,
        };
}