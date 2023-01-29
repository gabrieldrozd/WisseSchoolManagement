using Wisse.Common.Results.Errors;

namespace Wisse.Common.Results;

public class Result<T> : Result
{
    public T Value { get; private init; }

    public static Result<T> Success(T value)
        => new() { IsSuccess = true, Value = value, Error = string.Empty};

    public static Result<T> Failure(ErrorType errorType) =>
        new() { IsSuccess = false, Value = default, Error = errorType.ToString() };
}