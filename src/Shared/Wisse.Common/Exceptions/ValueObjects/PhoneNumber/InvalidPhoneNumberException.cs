namespace Wisse.Common.Exceptions.ValueObjects.PhoneNumber;

internal class InvalidPhoneNumberException : DomainException
{
    public InvalidPhoneNumberException()
        : base("Phone number is invalid.")
    {
    }
}