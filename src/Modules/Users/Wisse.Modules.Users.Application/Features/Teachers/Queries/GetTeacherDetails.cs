using Wisse.Common.Communication.Internal;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;

namespace Wisse.Modules.Users.Application.Features.Teachers.Queries;

public record GetTeacherDetails(Guid TeacherId) : IQuery<TeacherDetailsDto>;