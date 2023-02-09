namespace Wisse.Common.Exceptions.ValueObjects.Email;

public class EmptyEmailException : DomainException
{
    public EmptyEmailException()
        : base("Empty email.")
    {
    }
}