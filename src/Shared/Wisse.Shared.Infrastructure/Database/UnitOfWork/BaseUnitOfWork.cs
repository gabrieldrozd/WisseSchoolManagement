using Microsoft.EntityFrameworkCore;
using Wisse.Base.Results;
using Wisse.Shared.Abstractions.Database.UnitOfWork;

namespace Wisse.Shared.Infrastructure.Database.UnitOfWork;

public abstract class BaseUnitOfWork<T> : IUnitOfWork
    where T : DbContext
{
    private readonly T _context;

    protected BaseUnitOfWork(T context)
    {
        _context = context;
    }

    public async Task<Result> CommitAsync(CancellationToken cancellationToken = default)
    {
        var commitStatus = true;
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            commitStatus = false;
            await transaction.RollbackAsync(cancellationToken);
        }

        return commitStatus
            ? Result.Success()
            : Result.DatabaseFailure();
    }
}