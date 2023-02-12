namespace Wisse.Common.Exceptions.ValueObjects.Permission;

public class EmptyPermissionException : DomainException
{
    public EmptyPermissionException()
        : base("Empty permission.")
    {
    }
}