using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.ValueObjects.Contact;

namespace Wisse.Modules.Users.Domain.Entities;

public class Contact : Entity
{
    public ZipCode ZipCode { get; private set; }
    public string ZipCodeCity { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }

    public Guid StudentExternalId { get; set; }
    public Student Student { get; set; }

    private Contact(Guid externalId)
        : base(externalId)
    {
    }

    private Contact(Guid externalId, ZipCode zipCode, string zipCodeCity,
        string state, string city, string street, string houseNumber)
        : this(externalId)
    {
        ZipCode = zipCode;
        ZipCodeCity = zipCodeCity;
        State = state;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public static Contact Create(ContactDefinition definition)
    {
        var zipCodeValue = new ZipCode(definition.ZipCode);

        return new Contact(Guid.NewGuid(), zipCodeValue, definition.ZipCodeCity,
            definition.State, definition.City, definition.Street, definition.HouseNumber);
    }
}
