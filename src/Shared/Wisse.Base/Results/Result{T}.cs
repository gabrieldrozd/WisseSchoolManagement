namespace Wisse.Base.Results;

public class Result<T> : Result
{
    public T Value { get; }

    private Result(T value, bool isSuccess = true, Error error = null) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
        => new(value);
}