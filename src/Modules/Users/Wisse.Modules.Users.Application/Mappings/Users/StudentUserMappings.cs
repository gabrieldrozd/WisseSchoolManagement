using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Users.Domain.Definitions.Users;

namespace Wisse.Modules.Users.Application.Mappings.Users;

public static class StudentUserMappings
{
    public static StudentUserDefinition ToDefinition(this EnrollmentDetailsContract model)
        => new()
        {
            Email = model.Contact.Email,
            UserName = model.Contact.Email,
            PhoneNumber = model.Contact.Phone,
            FirstName = model.Applicant.FirstName,
            LastName = model.Applicant.LastName
        };
}
