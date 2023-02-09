namespace Wisse.Common.Exceptions.ValueObjects.Phone;

internal class InvalidPhoneException : DomainException
{
    public InvalidPhoneException()
        : base("Phone is invalid.")
    {
    }
}