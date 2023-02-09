using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Application.Mappings;

public static class UserMappings
{
    public static UserDefinition ToDefinition(this EnrollmentDetailsContract model)
        => new()
        {
            Email = model.Contact.Email,
            PhoneNumber = model.Contact.PhoneNumber,
            FirstName = model.Applicant.FirstName,
            LastName = model.Applicant.LastName
        };
}
