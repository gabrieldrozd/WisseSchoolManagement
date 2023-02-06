using Wisse.Modules.Enrollments.Application.DTO.Commands.Contact;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Contact;
using Wisse.Modules.Enrollments.Domain.Definitions;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings.DTO;

public static class ContactMappings
{
    public static ContactDetailsDto ToContactDetailsDto(this Contact model)
        => new()
        {
            Email = model.Email.Value,
            Phone = model.Phone.Value,
            ZipCode = model.ZipCode.Value,
            ZipCodeCity = model.ZipCodeCity,
            State = model.State,
            City = model.City,
            Street = model.Street,
            HouseNumber = model.HouseNumber
        };

    public static ContactDto ToContactDto(this Contact model)
        => new()
        {
            Email = model.Email.Value,
            Phone = model.Phone.Value,
        };

    public static ContactDefinition ToDefinition(this ContactPostDto dto)
        => new()
        {
            Id = dto.Id,
            Email = dto.Email,
            Phone = dto.Phone,
            ZipCode = dto.ZipCode,
            ZipCodeCity = dto.ZipCodeCity,
            State = dto.State,
            City = dto.City,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber
        };
}