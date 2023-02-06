using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings.Contract;

public static class EnrollmentContractMappings
{
    public static EnrollmentDetailsContract ToContract(this Enrollment model)
        => new()
        {
            ExternalId = model.ExternalId,
            EnrollmentDate = model.EnrollmentDate.ToDateTime(),
            EnrollmentStatus = model.EnrollmentStatus.Value,
            Applicant = model.Applicant.ToContract(),
            Contact = model.Contact.ToContract()
        };
}