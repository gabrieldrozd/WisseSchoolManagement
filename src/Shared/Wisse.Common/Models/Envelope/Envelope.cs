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

    public Envelope(bool isSuccess, params Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? Array.Empty<Error>();
        HasErrors = errors?.Length > 0;
    }

    public Envelope WithCode(int code)
    {
        StatusCode = code;
        return this;
    }
}