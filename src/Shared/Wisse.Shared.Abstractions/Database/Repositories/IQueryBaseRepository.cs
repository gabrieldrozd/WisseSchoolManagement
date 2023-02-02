using Wisse.Common.Domain.Primitives;

namespace Wisse.Shared.Abstractions.Database.Repositories;

public interface IQueryBaseRepository<in TEntity>
    where TEntity : Entity
{
    Task<int> TotalCountAsync();
}