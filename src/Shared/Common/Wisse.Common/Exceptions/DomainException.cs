namespace Wisse.Common.Exceptions;

public abstract class DomainException : CoreException
{
    protected DomainException(string message) : base(message)
    {
    }
}