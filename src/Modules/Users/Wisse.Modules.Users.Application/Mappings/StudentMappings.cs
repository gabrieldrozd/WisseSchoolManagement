using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Application.Mappings;

internal static class StudentMappings
{
    public static StudentDefinition ToDefinition(this ApplicantDetailsContract model)
        => new()
        {
            BirthDate = model.BirthDate,
            School = model.Education.School,
            Grade = model.Education.Grade,
            LevelKey = model.LanguageLevel.Key
        };
}