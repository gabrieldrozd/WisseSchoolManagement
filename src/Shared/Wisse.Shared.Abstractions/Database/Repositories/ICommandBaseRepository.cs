using Wisse.Common.Domain.Primitives;

namespace Wisse.Shared.Abstractions.Database.Repositories;

public interface ICommandBaseRepository<in TEntity>
    where TEntity : Entity
{
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}