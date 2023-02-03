using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.LanguageLevel;

internal class InvalidLanguageLevelException : DomainException
{
    public InvalidLanguageLevelException()
        : base("Invalid language level.")
    {
    }
}
