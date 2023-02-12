namespace Wisse.Common.Exceptions;

public abstract class NotFoundException : CoreException
{
    protected NotFoundException(string objectName, Guid objectId = default)
        : base(objectId.Equals(Guid.Empty)
            ? $"{objectName} was not found."
            : $"{objectName} with: '{objectId:D}' was not found.")
    {
    }
}