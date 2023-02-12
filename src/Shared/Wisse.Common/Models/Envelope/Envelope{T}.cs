using Wisse.Base.Results.Core;

namespace Wisse.Common.Models.Envelope;

public class Envelope<T> : Envelope
{
    public T Data { get; set; }

    public Envelope(T data)
    {
        Data = data;
    }

    public Envelope(T data, bool isSuccess, Error error = null) : base(isSuccess, error)
    {
        Data = data;
    }

    public Envelope(T data, bool isSuccess, Error[] errors = null) : base(isSuccess, errors)
    {
        Data = data;
    }

    public Envelope(Error error = null) : base(false, error)
    {
        Data = default;
    }

    public Envelope(Error[] errors = null) : base(false, errors)
    {
        Data = default;
    }

    public Envelope<T> WithCode(int code)
    {
        StatusCode = code;
        return this;
    }
}