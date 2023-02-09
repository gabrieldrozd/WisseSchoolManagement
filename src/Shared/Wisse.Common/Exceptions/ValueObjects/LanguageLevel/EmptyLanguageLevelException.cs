namespace Wisse.Common.Exceptions.ValueObjects.LanguageLevel;

public class EmptyLanguageLevelException : DomainException
{
    public EmptyLanguageLevelException()
        : base("Empty language level.")
    {
    }
}