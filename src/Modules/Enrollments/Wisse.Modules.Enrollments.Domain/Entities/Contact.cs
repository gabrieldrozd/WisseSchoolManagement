using Wisse.Common.Domain.Primitives;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Contact : Entity
{
    // TODO: Implement valueObjects for:
    // - Email
    // - Phone
    // - ZipCode
    // And maybe rest, to prevent primitive obsession

    public string Email { get; private set; }
    public string Phone { get; private set; }

    public string ZipCode { get; private set; }
    public string ZipCodeCity { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }

    private Contact(Guid id)
        : base(id)
    {
    }

    private Contact(Guid id, string email, string phone, string zipCode, string zipCodeCity, string state, string city,
        string street, string houseNumber)
        : this(id)
    {
        Email = email;
        Phone = phone;
        ZipCode = zipCode;
        ZipCodeCity = zipCodeCity;
        State = state;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public static Contact Create(Guid id, string email, string phone, string zipCode, string zipCodeCity, string state,
        string city, string street, string houseNumber)
    {
        return new Contact(id, email, phone, zipCode, zipCodeCity, state, city, street, houseNumber);
    }
}