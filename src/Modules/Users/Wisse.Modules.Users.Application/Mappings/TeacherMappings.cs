using Wisse.Modules.Users.Application.DTO.Queries.Teacher;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Mappings;

public static class TeacherMappings
{
    public static TeacherDetailsDto ToTeacherDetailsDto(this Teacher model)
        => new()
        {
            ExternalId = model.ExternalId,
            FirstName = model.User.FirstName.Value,
            LastName = model.User.LastName.Value,
            Email = model.User.Email.Value,
            PhoneNumber = model.User.PhoneNumber.Value
        };

    public static TeacherDto ToTeacherDto(this Teacher model)
        => new()
        {
            ExternalId = model.ExternalId,
            FirstName = model.User.FirstName.Value,
            LastName = model.User.LastName.Value,
            Email = model.User.Email.Value,
            PhoneNumber = model.User.PhoneNumber.Value
        };

    // public static StudentDefinition ToDefinition(this ApplicantDetailsContract model)
    //     => new()
    //     {
    //         BirthDate = model.BirthDate,
    //         School = model.Education.School,
    //         Grade = model.Education.Grade,
    //         LevelKey = model.LanguageLevel.Key
    //     };
}