namespace Wisse.Base.Results.Core;

public record Error(string Code, string Message)
{
    public static Error Create(string code, string message) => new(code, message);

    public static implicit operator string(Error error) => error.Code;

    #region Internal Errors

    internal static Error None()
        => Create(string.Empty, string.Empty);

    internal static Error NotFound(string objectName, Guid id)
        => id.Equals(Guid.Empty)
            ? Create("NotFound", $"{objectName.GetType().Name} was not found.")
            : Create("NotFound", $"{objectName.GetType().Name} with: '{id:D}' was not found.");

    internal static Error DatabaseFailure()
        => Create("DatabaseFailure", "Database failed to process changes.");

    #endregion

    #region Public Errors

    public static Error Unexpected()
        => Create("Unexpected", "An unexpected error occurred.");

    #endregion
}