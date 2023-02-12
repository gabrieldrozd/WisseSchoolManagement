using Wisse.Base.Results;
using Wisse.Modules.Users.Application.Features.Auth.Queries;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Auth;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Modules.Users.Infrastructure.Queries.Auth;

internal sealed class GetCurrentUserHandler : IQueryHandler<GetCurrentUser, AccessToken>
{
    private readonly IContext _context;
    private readonly IQueryUserRepository _queryUserRepository;
    private readonly ITokenProvider _tokenProvider;

    public GetCurrentUserHandler(
        IContext context,
        IQueryUserRepository queryUserRepository,
        ITokenProvider tokenProvider)
    {
        _context = context;
        _queryUserRepository = queryUserRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<AccessToken>> HandleAsync(GetCurrentUser query, CancellationToken cancellationToken = default)
    {
        var user = await _queryUserRepository.GetAsync(x => x.ExternalId == _context.User.UserId);
        if (user is null)
        {
            return Result.Unauthorized<AccessToken>();
        }

        var token = _tokenProvider.CreateToken(
            user.ExternalId,
            user.Email,
            user.Role,
            user.Permissions);

        return Result.Success(token);
    }
}