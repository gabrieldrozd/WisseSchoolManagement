using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;

namespace Wisse.Modules.Users.Application.Features.Teachers.Queries;

public record BrowseTeachers(Pagination Pagination) : IQuery<PaginatedList<TeacherDto>>;