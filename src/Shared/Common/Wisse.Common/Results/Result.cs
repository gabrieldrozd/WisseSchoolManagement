namespace Wisse.Common.Results;

public class Result
{
    public static DataResult<T> Success<T>(T value)
        => DataResult<T>.Success(value);
}