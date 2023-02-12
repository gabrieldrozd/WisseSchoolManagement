namespace Wisse.Common.Exceptions.Infrastructural;

public class AuthorizationException : AuthException
{
    public AuthorizationException()
        : base("Something went wrong during authorization. Please try to login again.")
    {
    }
}
