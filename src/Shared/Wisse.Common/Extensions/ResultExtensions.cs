using Microsoft.AspNetCore.Http;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Common.Models.Envelope;

namespace Wisse.Common.Extensions;

public static class ResultExtensions
{
    public static EmptyEnvelope ToEnvelope(this Result result)
    {
        return result.Status switch
        {
            Status.Success when result.IsSuccess => new EmptyEnvelope(),
            Status.Failure when result.IsFailure => new EmptyEnvelope(result.Error),
            Status.NotFound when result.IsFailure => new EmptyEnvelope(result.Error),
            _ => new EmptyEnvelope(Error.Unexpected())
        };
    }

    public static Envelope<T> ToEnvelope<T>(this Result<T> result)
    {
        return result.Status switch
        {
            Status.Success when result.IsSuccess => new Envelope<T>(result.Value),
            Status.Failure when result.IsFailure => new Envelope<T>(result.Error),
            Status.NotFound when result.IsFailure => new Envelope<T>(result.Error),
            _ => new Envelope<T>(Error.Unexpected())
        };
    }

    public static int GetStatusCode(this Result result)
    {
        return result.Status switch
        {
            Status.Success when result.IsSuccess => StatusCodes.Status200OK,
            Status.Failure when result.IsFailure => StatusCodes.Status400BadRequest,
            Status.NotFound when result.IsFailure => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    public static int GetStatusCode<T>(this Result<T> result)
    {
        return ((Result) result).GetStatusCode();
    }
}