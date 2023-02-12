namespace Wisse.Common.Exceptions.ValueObjects.Permission;

public class InvalidPermissionException : DomainException
{
    public InvalidPermissionException()
        : base("Invalid permission.")
    {
    }
}
