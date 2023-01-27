using Wisse.Common.Exceptions;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.LanguageLevel;

internal class EmptyLanguageLevelException : DomainException
{
    public EmptyLanguageLevelException()
        : base("Empty language level.")
    {
    }
}