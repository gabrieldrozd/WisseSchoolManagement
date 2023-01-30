using Wisse.Common.Messaging.Mediator;
using Wisse.Common.Models.Pagination.Core;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

public record BrowseEnrollments(Pagination Pagination) : IQuery<PaginatedList<EnrollmentDto>>;