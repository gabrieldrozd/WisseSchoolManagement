namespace Wisse.Modules.Users.Application.DTO.Queries.Teacher;

public class TeacherDto
{
    public Guid ExternalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    // TODO: Add more properties once Teacher entity will grow
    // ** TeacherDto will be different than TeacherDetailsDto **
}