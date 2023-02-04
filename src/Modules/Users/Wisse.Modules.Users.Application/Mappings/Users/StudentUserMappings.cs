using Wisse.Modules.Users.Application.Events.EnrollmentApproved.DTO;
using Wisse.Modules.Users.Domain.Definitions.Users;

namespace Wisse.Modules.Users.Application.Mappings.Users;

internal static class StudentUserMappings
{
    public static StudentUserDefinition ToDefinition(this EnrollmentDetailsDto model)
        => new()
        {
            Email = model.Contact.Email,
            UserName = model.Contact.Email,
            PhoneNumber = model.Contact.Phone,
            FirstName = model.Applicant.FirstName,
            LastName = model.Applicant.LastName
        };
}
