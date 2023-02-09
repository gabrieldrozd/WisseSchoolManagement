namespace Wisse.Common.Exceptions.ValueObjects.LanguageLevel;

public class InvalidLanguageLevelException : DomainException
{
    public InvalidLanguageLevelException()
        : base("Invalid language level.")
    {
    }
}
