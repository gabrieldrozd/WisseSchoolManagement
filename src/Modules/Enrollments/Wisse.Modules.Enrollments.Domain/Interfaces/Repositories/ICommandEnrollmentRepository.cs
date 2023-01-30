using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;

public interface ICommandEnrollmentRepository : IBaseRepository<Enrollment>
{
}