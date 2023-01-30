using Microsoft.AspNetCore.Mvc;

namespace Wisse.Common.Api.Controllers;

public class ProducesDefaultContentTypeAttribute : ProducesAttribute
{
    public ProducesDefaultContentTypeAttribute(Type type)
        : base(type)
    {
    }

    public ProducesDefaultContentTypeAttribute(params string[] additionalContentTypes)
        : base("application/json", additionalContentTypes)
    {
    }
}
