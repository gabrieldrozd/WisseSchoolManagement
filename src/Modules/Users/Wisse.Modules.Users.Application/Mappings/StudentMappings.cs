using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Users.Application.DTO.Queries.Student;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Mappings;

public static class StudentMappings
{
    public static StudentDetailsDto ToStudentDetailsDto(this Student model)
        => new()
        {
            ExternalId = model.ExternalId,
            FirstName = model.User.FirstName.Value,
            LastName = model.User.LastName.Value,
            Email = model.User.Email.Value,
            PhoneNumber = model.User.PhoneNumber.Value,
            BirthDate = model.BirthDate.ToDateTime(),
            Education = new EducationDto
            {
                School = model.EducationDetails.School,
                Grade = model.EducationDetails.Grade
            },
            LanguageLevel = new LanguageLevelDto
            {
                Key = model.LanguageLevel.Key,
                Name = model.LanguageLevel.Name
            },
            Contact = model.Contact.ToContactDetailsDto()
        };

    public static StudentDto ToStudentDto(this Student model)
        => new()
        {
            ExternalId = model.ExternalId,
            FirstName = model.User.FirstName.Value,
            LastName = model.User.LastName.Value,
            Email = model.User.Email.Value,
            PhoneNumber = model.User.PhoneNumber.Value,
            BirthDate = model.BirthDate.ToDateTime()
        };

    public static StudentDefinition ToDefinition(this ApplicantDetailsContract model)
        => new()
        {
            BirthDate = model.BirthDate,
            School = model.Education.School,
            Grade = model.Education.Grade,
            LevelKey = model.LanguageLevel.Key
        };
}