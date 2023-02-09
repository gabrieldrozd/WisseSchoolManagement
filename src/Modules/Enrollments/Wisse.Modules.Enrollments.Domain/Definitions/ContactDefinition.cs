namespace Wisse.Modules.Enrollments.Domain.Definitions;

public class ContactDefinition
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ZipCode { get; set; }
    public string ZipCodeCity { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
}