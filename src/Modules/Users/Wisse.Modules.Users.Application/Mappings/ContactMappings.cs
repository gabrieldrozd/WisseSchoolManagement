using Wisse.Modules.Users.Application.Events.EnrollmentApproved.DTO;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Application.Mappings;

internal static class ContactMappings
{
    public static ContactDefinition ToDefinition(this ContactDetailsDto model)
        => new()
        {
            ZipCode = model.ZipCode,
            ZipCodeCity = model.ZipCodeCity,
            State = model.State,
            City = model.City,
            Street = model.Street,
            HouseNumber = model.HouseNumber
        };
}