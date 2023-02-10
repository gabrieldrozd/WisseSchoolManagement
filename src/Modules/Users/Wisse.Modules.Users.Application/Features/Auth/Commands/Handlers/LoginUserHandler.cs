using Wisse.Base.Results;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Modules.Users.Domain.Interfaces.Services;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Features.Auth.Commands.Handlers;

internal sealed class LoginUserHandler : ICommandHandler<LoginUser>
{
    private readonly IQueryUserRepository _queryUserRepository;
    private readonly IIdentityService _identityService;

    public LoginUserHandler(
        IQueryUserRepository queryUserRepository,
        IIdentityService identityService)
    {
        _queryUserRepository = queryUserRepository;
        _identityService = identityService;
    }

    public async Task<Result> HandleAsync(LoginUser command, CancellationToken cancellationToken = default)
    {
        var user = await _queryUserRepository.GetByEmailAsync(command.Email);
        if (user is null)
        {
            return Result.Unauthorized();
        }

        var loginResult = _identityService.Login(user, command.Password);
        return loginResult.IsSuccess
            ? loginResult
            : Result.Unauthorized();
    }
}