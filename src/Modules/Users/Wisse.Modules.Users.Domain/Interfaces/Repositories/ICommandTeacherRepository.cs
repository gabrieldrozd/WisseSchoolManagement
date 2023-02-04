using Wisse.Modules.Users.Domain.Entities;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Users.Domain.Interfaces.Repositories;

public interface ICommandTeacherRepository : ICommandBaseRepository<Teacher>
{
}