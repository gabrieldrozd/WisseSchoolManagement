using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Constants;

internal static class ApplicantConstants
{
    public const string ApplicantTableName = $"{nameof(Applicant)}s";

    public const int FirstNameMaxLength = 50;
    public const int LastNameMaxLength = 50;
    public const int EducationDetailsMaxLength = 80;
    public const int LanguageLevelMaxLength = 80;
}