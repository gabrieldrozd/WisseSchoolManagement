namespace Wisse.Common.Results.Errors;

public class DatabaseErrorCode : ErrorCode
{
    private const string CoreCode = "Database";

    public static readonly ErrorCode SaveFailure = new SaveFailureError();

    protected DatabaseErrorCode(string code, string message) : base(code, message)
    {
    }

    private sealed class SaveFailureError : ErrorCode
    {
        public SaveFailureError() : base($"{CoreCode}.SaveFailure", "Failed to save data to database")
        {
        }
    }
}