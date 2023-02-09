namespace Wisse.Common.Exceptions.ValueObjects.Phone;

internal class EmptyPhoneException : DomainException
{
    public EmptyPhoneException()
        : base("Phone cannot be empty.")
    {
    }
}