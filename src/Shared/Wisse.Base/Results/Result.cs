using Wisse.Base.Results.Core;

namespace Wisse.Base.Results;

public class Result
{
    public Status Status { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    private Result(Status status, bool isSuccess = true, Error error = null)
    {
        Status = status;
        IsSuccess = isSuccess;
        Error = error switch
        {
            null => Error.None(),
            _ => error
        };
    }

    #region Result

    public static Result Success()
        => new(Status.Success);

    public static Result Failure(Failure failure)
        => new(Status.Failure, false, Error.Create(failure.Code, failure.Message));

    public static Result NotFound(string objectName, Guid id = default)
        => new(Status.NotFound, false, Error.NotFound(objectName, id));

    public static Result DatabaseFailure()
        => new(Status.Failure, false, Error.DatabaseFailure());

    #endregion

    #region Result<T>

    public static Result<T> Success<T>(T value)
        => Result<T>.Success(value);

    public static Result<T> Failure<T>(Failure failure)
        => Result<T>.Failure(failure);

    public static Result<T> NotFound<T>(string objectName, Guid id = default)
        => Result<T>.NotFound(objectName, id);

    public static Result<T> DatabaseFailure<T>()
        => Result<T>.DatabaseFailure();

    #endregion
}