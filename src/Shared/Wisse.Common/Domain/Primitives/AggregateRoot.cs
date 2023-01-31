namespace Wisse.Common.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid externalId)
        : base(externalId)
    {
    }
}
