using Wisse.Common.Results.Errors;

namespace Wisse.Common.Results;

public class Error
{
    public static readonly Error None = Create(ErrorCode.None);

    public string Code { get; }
    public string Message { get; }

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error Create(ErrorCode code)
        => new(code.Code, code.Message);

    public static implicit operator string(Error error) => error.Code;
}