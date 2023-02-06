using Wisse.Base.Results.Core;

namespace Wisse.Base.Results;

public class Result<T>
{
    public T Value { get; }
    public Status Status { get; }
    public bool IsSuccess { get; }
    public Error Error { get; }

    public Result()
    {
    }

    private Result(T value, Status status, bool isSuccess = true, Error error = null)
    {
        Value = value;
        Status = status;
        IsSuccess = isSuccess;
        Error = error switch
        {
            null => Error.None(),
            _ => error
        };
    }

    private Result(Status status, bool isSuccess, Error error)
    {
        Value = default;
        Status = status;
        IsSuccess = isSuccess;
        Error = error switch
        {
            null => Error.None(),
            _ => error
        };
    }

    #region Result<T>

    public static Result<T> Success(T value)
        => new(value, Status.Success);

    public static Result<T> Failure(Failure failure)
        => new(Status.Failure, false, Error.Create(failure.Code, failure.Message));

    public static Result<T> NotFound(string objectName, Guid id = default)
        => new(Status.NotFound, false, Error.NotFound(objectName, id));

    public static Result<T> DatabaseFailure()
        => new(Status.Failure, false, Error.DatabaseFailure());

    #endregion

    #region Operators

    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }

    public static implicit operator Result(Result<T> result)
    {
        return result.IsSuccess
            ? Result.Success()
            : Result.Failure(Core.Failure.FromCode(result.Error.Code));
    }

    #endregion
}