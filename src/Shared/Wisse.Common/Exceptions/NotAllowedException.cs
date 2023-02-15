namespace Wisse.Common.Exceptions;

public sealed class NotAllowedException : CoreException
{
    public NotAllowedException() : base("Not allowed. Lack of sufficient permissions.")
    {
    }
}