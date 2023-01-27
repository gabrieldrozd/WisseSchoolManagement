namespace Wisse.Common.Exceptions;

public abstract class CoreException : Exception
{
    protected CoreException(string message) : base(message)
    {
    }
}