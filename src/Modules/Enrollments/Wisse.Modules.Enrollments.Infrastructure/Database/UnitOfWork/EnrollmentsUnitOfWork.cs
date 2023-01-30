using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Infrastructure.Database.UnitOfWork;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.UnitOfWork;

internal class EnrollmentsUnitOfWork : BaseUnitOfWork<EnrollmentsDbContext>, IEnrollmentsUnitOfWork
{
    public EnrollmentsUnitOfWork(EnrollmentsDbContext context)
        : base(context)
    {
    }
}