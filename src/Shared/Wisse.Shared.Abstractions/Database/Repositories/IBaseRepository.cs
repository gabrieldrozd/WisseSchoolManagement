using Wisse.Common.Domain.Primitives;
using Wisse.Common.Utilities.Configuration;

namespace Wisse.Shared.Abstractions.Database.Repositories;

public interface IBaseRepository<in TEntity> : IRepository
    where TEntity : Entity
{
    Task<int> TotalCountAsync();
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}