namespace Wisse.Common.Exceptions;

public sealed class NotAuthenticatedException : CoreException
{
    public NotAuthenticatedException() : base("Not authenticated. Please login first or refresh token.")
    {
    }
}