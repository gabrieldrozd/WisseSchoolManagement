using Wisse.Common.Exceptions;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.LanguageLevel;

internal class EmptyLanguageLevelException : DomainException
{
    public EmptyLanguageLevelException()
        : base("Empty language level.")
    {
    }
}