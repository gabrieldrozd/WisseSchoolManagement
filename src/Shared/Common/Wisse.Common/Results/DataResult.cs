namespace Wisse.Common.Results;

public class DataResult<T>
{
    public bool IsSuccess { get; private init; }

    public bool IsFailure { get; private init; }

    public T Value { get; private init; }

    public string Error { get; private init; }

    public static DataResult<T> Success(T value)
        => new() { IsSuccess = true, IsFailure = false, Value = value, Error = string.Empty};
}