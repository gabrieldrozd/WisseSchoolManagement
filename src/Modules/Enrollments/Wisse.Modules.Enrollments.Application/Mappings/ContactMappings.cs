using Wisse.Modules.Enrollments.Application.DTO.Contact;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings;

public static class ContactMappings
{
    public static ContactDetailsDto ToContactDetailsDto(this Contact model)
    {
        return new ContactDetailsDto
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
    }
}