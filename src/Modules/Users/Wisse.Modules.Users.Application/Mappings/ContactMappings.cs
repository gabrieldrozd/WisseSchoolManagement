using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Users.Application.DTO.Queries.Contact;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Mappings;

public static class ContactMappings
{
    public static ContactDetailsDto ToContactDetailsDto(this Contact model)
        => new()
        {
            ZipCode = model.ZipCode.Value,
            ZipCodeCity = model.ZipCodeCity,
            State = model.State,
            City = model.City,
            Street = model.Street,
            HouseNumber = model.HouseNumber
        };

    public static ContactDefinition ToDefinition(this ContactDetailsContract model)
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