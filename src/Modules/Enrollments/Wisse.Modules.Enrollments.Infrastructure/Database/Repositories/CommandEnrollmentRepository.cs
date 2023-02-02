using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Repositories;

internal class CommandEnrollmentRepository
    : CommandBaseRepository<Enrollment, EnrollmentsDbContext>,
      ICommandEnrollmentRepository
{
    public CommandEnrollmentRepository(EnrollmentsDbContext context)
        : base(context)
    {
    }
}