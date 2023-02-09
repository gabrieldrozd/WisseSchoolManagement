using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings.Contract;

public static class ContactContractMappings
{
    public static ContactDetailsContract ToContract(this Contact model)
        => new()
        {
            Email = model.Email.Value,
            PhoneNumber = model.PhoneNumber.Value,
            ZipCode = model.ZipCode.Value,
            ZipCodeCity = model.ZipCodeCity,
            State = model.State,
            City = model.City,
            Street = model.Street,
            HouseNumber = model.HouseNumber
        };
}