using Wisse.Common.Domain.Primitives;
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

    public Guid EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    private Contact(Guid id)
        : base(id)
    {
    }

    private Contact(Guid id, Email email, Phone phone, ZipCode zipCode, string zipCodeCity,
        string state, string city, string street, string houseNumber)
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

    public static Contact Create(Guid id, string email, string phone, string zipCode, string zipCodeCity,
        string state, string city, string street, string houseNumber)
    {
        var emailValue = new Email(email);
        var phoneValue = new Phone(phone);
        var zipCodeValue = new ZipCode(zipCode);

        return new Contact(id, emailValue, phoneValue, zipCodeValue, zipCodeCity, state, city, street, houseNumber);
    }
}