using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Definitions;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Contact;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Contact : Entity
{
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }

    public ZipCode ZipCode { get; private set; }
    public string ZipCodeCity { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }

    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    private Contact(Guid externalId)
        : base(externalId)
    {
    }

    private Contact(Guid externalId, Email email, Phone phone, ZipCode zipCode, string zipCodeCity,
        string state, string city, string street, string houseNumber)
        : this(externalId)
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

    public static Contact Create(ContactDefinition definition)
    {
        var emailValue = new Email(definition.Email);
        var phoneValue = new Phone(definition.Phone);
        var zipCodeValue = new ZipCode(definition.ZipCode);

        return new Contact(definition.Id, emailValue, phoneValue, zipCodeValue, definition.ZipCodeCity,
            definition.State, definition.City, definition.Street, definition.HouseNumber);
    }
}