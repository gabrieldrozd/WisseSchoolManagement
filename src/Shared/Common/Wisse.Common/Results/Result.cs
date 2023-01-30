using Wisse.Common.Results.Errors;

namespace Wisse.Common.Results;

public class Result
{
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; protected init; }

    protected Result(bool isSuccess = true, Error error = null)
    {
        IsSuccess = isSuccess;
        Error = error switch
        {
            null => Error.None,
            _ => error
        };
    }



    public static Result Success()
        => new();

    public static Result<T> Success<T>(T value)
        => Result<T>.Success(value);

    public static Result Failure(ErrorCode errorCode)
        => new(false, Error.Create(errorCode));
}