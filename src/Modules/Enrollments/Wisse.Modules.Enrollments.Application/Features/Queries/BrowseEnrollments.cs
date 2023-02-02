using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

public record BrowseEnrollments(Pagination Pagination) : IQuery<PaginatedList<EnrollmentDto>>;