using Wisse.Modules.Users.Application.DTO.Queries.Contact;

namespace Wisse.Modules.Users.Application.DTO.Queries.Student;

public class StudentDetailsDto
{
    public Guid ExternalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public EducationDto Education { get; set; }
    public LanguageLevelDto LanguageLevel { get; set; }
    public ContactDetailsDto Contact { get; set; }
}