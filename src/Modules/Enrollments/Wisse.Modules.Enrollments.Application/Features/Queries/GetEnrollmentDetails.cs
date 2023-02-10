using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Features.Queries;

[QueryEntityName(typeof(Enrollment))]
public record GetEnrollmentDetails(Guid EnrollmentId) : IQuery<EnrollmentDetailsDto>;