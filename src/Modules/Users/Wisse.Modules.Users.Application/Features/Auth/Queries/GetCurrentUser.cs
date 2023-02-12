using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Shared.Abstractions.Auth;

namespace Wisse.Modules.Users.Application.Features.Auth.Queries;

[QueryEntityName(typeof(User))]
public record GetCurrentUser : IQuery<AccessToken>;