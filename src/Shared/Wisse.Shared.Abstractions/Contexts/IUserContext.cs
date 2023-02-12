using Wisse.Common.Domain.ValueObjects;

namespace Wisse.Shared.Abstractions.Contexts;

public interface IUserContext
{
    public Guid UserId { get; set; }
    public Email Email { get; set; }
    public Role Role { get; set; }
    public List<Permission> Permissions { get; set; }
}