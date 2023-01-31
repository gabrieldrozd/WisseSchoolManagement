using Wisse.Base.Results.Core;

namespace Wisse.Common.Models.Envelope;

public class EmptyEnvelope : Envelope<EmptyData>
{
    public EmptyEnvelope()
        : base(new EmptyData())
    {
    }

    public EmptyEnvelope(Error error)
        : base(error)
    {
    }

    public EmptyEnvelope(Error[] errors)
        : base(errors)
    {
    }
}