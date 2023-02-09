namespace Wisse.Common.Exceptions.ValueObjects.Role;

internal class EmptyUserRoleException : DomainException
{
    public EmptyUserRoleException()
        : base("User role cannot be empty.")
    {
    }
}