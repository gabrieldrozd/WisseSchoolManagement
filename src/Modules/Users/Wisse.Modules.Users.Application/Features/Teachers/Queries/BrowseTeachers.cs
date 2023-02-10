using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Features.Teachers.Queries;

[QueryEntityName(typeof(Teacher))]
public record BrowseTeachers(Pagination Pagination) : IQuery<PaginatedList<TeacherDto>>;