using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Models.Envelope;

namespace Wisse.Common.Controllers;

public class ProducesEnvelopeAttribute : ProducesResponseTypeAttribute
{
    public ProducesEnvelopeAttribute(Type objType, int statusCode)
        : base(statusCode)
    {
        Type = typeof(Envelope<>).MakeGenericType(objType);
    }
}