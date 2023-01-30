using Wisse.Common.Results;

namespace Wisse.Shared.Abstractions.Database.UnitOfWork;

public interface IUnitOfWork
{
    Task<Result> CommitAsync(CancellationToken cancellationToken = default);
}