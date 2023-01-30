using Wisse.Common.Utilities.Messaging.Mediator;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

public record GetEnrollmentDetails(Guid EnrollmentId) : IQuery<EnrollmentDetailsDto>;