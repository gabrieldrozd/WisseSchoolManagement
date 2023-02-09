namespace Wisse.Common.Exceptions.ValueObjects;

public class EmptyLanguageLevelException : DomainException
{
    public EmptyLanguageLevelException()
        : base("Empty language level.")
    {
    }
}