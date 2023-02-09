namespace Wisse.Modules.Enrollments.Application.DTO.Commands.Contact;

public class ContactPostDto
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ZipCode { get; set; }
    public string ZipCodeCity { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
}