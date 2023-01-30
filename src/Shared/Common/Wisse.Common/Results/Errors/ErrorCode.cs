using Wisse.Common.Types;

namespace Wisse.Common.Results.Errors;

public class ErrorCode : ErrorEnumeration<ErrorCode>
{
    private const string CoreCode = "Core";

    public static readonly ErrorCode None = new NoError();
    public static readonly ErrorCode NullValue = new NullValueError();

    protected ErrorCode(string code, string message) : base(code, message)
    {
    }

    public static ErrorCode Create(ErrorCode current, string message)
        => new(current.Code, $"{current.Message}. {message}");

    private sealed class NoError : ErrorCode
    {
        public NoError() : base(string.Empty, string.Empty)
        {
        }
    }

    private sealed class NullValueError : ErrorCode
    {
        public NullValueError() : base($"{CoreCode}.NullValue", "Value cannot be null")
        {
        }
    }
}