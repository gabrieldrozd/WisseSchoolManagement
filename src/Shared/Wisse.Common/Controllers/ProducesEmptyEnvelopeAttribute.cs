using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Models.Envelope;

namespace Wisse.Common.Controllers;

public class ProducesEmptyEnvelopeAttribute : ProducesResponseTypeAttribute
{
    public ProducesEmptyEnvelopeAttribute(int statusCode)
        : base(typeof(EmptyEnvelope), statusCode)
    {
    }
}