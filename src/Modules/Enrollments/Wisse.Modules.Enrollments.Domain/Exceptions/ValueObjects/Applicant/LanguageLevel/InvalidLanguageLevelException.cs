using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.LanguageLevel;

internal class InvalidLanguageLevelException : DomainException
{
    public InvalidLanguageLevelException()
        : base("Invalid language level.")
    {
    }
}
