using Wisse.Common.Models;
using Wisse.Common.Utilities.Messaging.Mediator;
using Wisse.Modules.Enrollments.Application.DTO.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

public record BrowseEnrollments(Pagination Pagination) : IQuery<PaginatedList<EnrollmentDto>>;