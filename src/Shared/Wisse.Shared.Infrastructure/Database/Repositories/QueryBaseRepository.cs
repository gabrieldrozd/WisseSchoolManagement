using Microsoft.EntityFrameworkCore;
using Wisse.Common.Domain.Primitives;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Shared.Infrastructure.Database.Repositories;

public class QueryBaseRepository<TEntity, TDbContext> : IQueryBaseRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    private readonly TDbContext _context;

    protected QueryBaseRepository(TDbContext context)
    {
        _context = context;
    }

    public Task<int> TotalCountAsync()
    {
        return _context.Set<TEntity>().CountAsync();
    }
}