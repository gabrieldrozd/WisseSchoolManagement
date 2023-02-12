namespace Wisse.Common.Exceptions;

public abstract class AuthException : CoreException
{
    protected AuthException(string message) : base(message)
    {
    }
}