using Wisse.Common.Communication.Internal;

namespace Wisse.Modules.Users.Application.Features.Auth.Commands;

public record LoginUser(string Email, string Password) : ICommand;