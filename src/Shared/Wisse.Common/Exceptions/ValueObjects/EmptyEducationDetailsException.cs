namespace Wisse.Common.Exceptions.ValueObjects;

public class EmptyEducationDetailsException : DomainException
{
    public EmptyEducationDetailsException()
        : base("Empty education details.")
    {
    }
}