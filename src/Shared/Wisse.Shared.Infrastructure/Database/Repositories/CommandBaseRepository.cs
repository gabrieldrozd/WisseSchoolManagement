using Microsoft.EntityFrameworkCore;
using Wisse.Common.Domain.Primitives;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Shared.Infrastructure.Database.Repositories;

public class CommandBaseRepository<TEntity, TDbContext> : ICommandBaseRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    private readonly TDbContext _context;

    protected CommandBaseRepository(TDbContext context)
    {
        _context = context;
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}