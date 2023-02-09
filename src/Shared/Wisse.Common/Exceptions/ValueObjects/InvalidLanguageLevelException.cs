namespace Wisse.Common.Exceptions.ValueObjects;

public class InvalidLanguageLevelException : DomainException
{
    public InvalidLanguageLevelException()
        : base("Invalid language level.")
    {
    }
}
