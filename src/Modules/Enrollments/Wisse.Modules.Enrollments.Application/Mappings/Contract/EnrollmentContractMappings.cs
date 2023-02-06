using Wisse.Contracts.EnrollmentsRequested.Contracts;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Mappings.Contract;

public static class EnrollmentContractMappings
{
    public static EnrollmentContract ToEnrollmentContract(this EnrollmentDto model)
        => new()
        {
            ExternalId = model.ExternalId,
            EnrollmentDate = model.EnrollmentDate,
            EnrollmentStatus = model.EnrollmentStatus
        };
}