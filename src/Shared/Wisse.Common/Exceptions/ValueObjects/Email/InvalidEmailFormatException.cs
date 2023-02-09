namespace Wisse.Common.Exceptions.ValueObjects.Email;

public class InvalidEmailFormatException : DomainException
{
    public InvalidEmailFormatException(string email) 
        : base($"Invalid email format: {email}")
    {
    }
}