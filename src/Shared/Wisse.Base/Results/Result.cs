namespace Wisse.Base.Results;

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
            null => Error.None(),
            _ => error
        };
    }

    public static Result Success()
        => new();

    public static Result<T> Success<T>(T value)
        => Result<T>.Success(value);

    public static Result Failure(Failure failure)
        => new(false, Error.Create(failure.Code, failure.Message));

    public static Result NotFound(string objectName, Guid id = default)
        => new(false, Error.NotFound(objectName, id));

    public static Result DatabaseFailure()
        => new(false, Error.DatabaseFailure());
}