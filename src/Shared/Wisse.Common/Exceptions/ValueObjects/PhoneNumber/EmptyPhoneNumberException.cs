namespace Wisse.Common.Exceptions.ValueObjects.PhoneNumber;

internal class EmptyPhoneNumberException : DomainException
{
    public EmptyPhoneNumberException()
        : base("Phone number cannot be empty.")
    {
    }
}