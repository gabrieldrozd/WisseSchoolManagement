namespace Wisse.Modules.Enrollments.Application.DTO.Commands.Applicant;

public class ApplicantPostDto
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string School { get; set; }
    public string Grade { get; set; }
    public string LevelKey { get; set; }
}