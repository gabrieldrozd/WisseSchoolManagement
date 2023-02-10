using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

[QueryEntityName(typeof(Enrollment))]
public record BrowseEnrollments(Pagination Pagination) : IQuery<PaginatedList<EnrollmentDto>>;