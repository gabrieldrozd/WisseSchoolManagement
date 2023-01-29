using Wisse.Common.Results.Errors;

namespace Wisse.Common.Results;

public class Result
{
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; protected init; }

    public static Result Success()
        => new() { IsSuccess = true};

    public static Result<T> Success<T>(T value)
        => Result<T>.Success(value);

    public static Result Failure(string error)
        => new() { IsSuccess = false, Error = error };

    public static Result Failure(ErrorType errorType)
        => new() { IsSuccess = false, Error = errorType.ToString() };

    public static Result<T> Failure<T>(ErrorType errorType)
        => Result<T>.Failure(errorType);
}