using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Application.DTO.Queries.Student;

namespace Wisse.Modules.Users.Application.Features.Students.Queries;

public record BrowseStudents(Pagination Pagination) : IQuery<PaginatedList<StudentDto>>;