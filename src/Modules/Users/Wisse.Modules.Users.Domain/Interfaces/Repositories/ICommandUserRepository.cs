using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Users.Domain.Interfaces.Repositories;

public interface ICommandUserRepository : ICommandBaseRepository<User>
{
}