using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Shared.Abstractions.Mediator.Query;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

public record GetEnrollmentDetails(Guid EnrollmentId) : IQuery<EnrollmentDetailsDto>;