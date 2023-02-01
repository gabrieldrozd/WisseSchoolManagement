using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Wisse.Common.Controllers.Types;

namespace Wisse.Common.Controllers;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Delegate | AttributeTargets.Class, Inherited = false)]
public class ControllerConfigurationAttribute : AreaAttribute, ITagsMetadata, IRouteTemplateProvider
{
    private int? _order;
    int? IRouteTemplateProvider.Order => _order;

    public IReadOnlyList<string> Tags { get; }
    [StringSyntax("Route")]
    public string Template { get; }
    public string Name { get; set; }

    public int? Order
    {
        get => _order ?? 0;
        set => _order = value;
    }

    public ControllerConfigurationAttribute(ControllerType type, string area, [StringSyntax("Route")] string route) :
        base(area)
    {
        Tags = new List<string> { $"{area} {type.ToString()}" };
        Template = route ?? throw new ArgumentNullException(nameof(route));
    }
}