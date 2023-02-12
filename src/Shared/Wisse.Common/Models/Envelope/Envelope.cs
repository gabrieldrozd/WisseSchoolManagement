using Wisse.Base.Results.Core;

namespace Wisse.Common.Models.Envelope;

public class Envelope
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public bool HasErrors { get; set; }
    public Error[] Errors { get; set; }

    public Envelope()
    {
        IsSuccess = true;
        Errors = Array.Empty<Error>();
    }

    public Envelope(bool isSuccess, Error error = null)
        : this(isSuccess, new[] { error })
    {
    }

    public Envelope(bool isSuccess, Error[] errors = null)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? Array.Empty<Error>();
        HasErrors = errors?.Length > 0;
    }
}