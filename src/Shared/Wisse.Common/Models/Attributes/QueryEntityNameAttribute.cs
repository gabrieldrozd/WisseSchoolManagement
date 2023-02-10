namespace Wisse.Common.Models.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class QueryEntityNameAttribute : Attribute
{
    public string EntityName { get; }

    public QueryEntityNameAttribute(Type entityType)
    {
        EntityName = entityType.Name;
    }
}
