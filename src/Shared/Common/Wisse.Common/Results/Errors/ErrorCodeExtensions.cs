namespace Wisse.Common.Results.Errors;

public static class ErrorCodeExtensions
{
    public static ErrorCode NotFoundWithId(this ErrorCode errorCode, string id)
    {
        const string notFound = "NotFound";

        return errorCode.Code.Contains(notFound)
            ? ErrorCode.Create(errorCode, $"Id: {id})")
            : errorCode;
    }
}