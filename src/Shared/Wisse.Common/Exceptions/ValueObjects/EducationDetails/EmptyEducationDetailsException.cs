namespace Wisse.Common.Exceptions.ValueObjects.EducationDetails;

public class EmptyEducationDetailsException : DomainException
{
    public EmptyEducationDetailsException()
        : base("Empty education details.")
    {
    }
}