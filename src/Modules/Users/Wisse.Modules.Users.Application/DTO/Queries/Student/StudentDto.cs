namespace Wisse.Modules.Users.Application.DTO.Queries.Student;

public class StudentDto
{
    public Guid ExternalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}
