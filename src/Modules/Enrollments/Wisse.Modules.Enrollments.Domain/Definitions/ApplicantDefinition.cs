namespace Wisse.Modules.Enrollments.Domain.Definitions;

public class ApplicantDefinition
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string School { get; set; }
    public string Grade { get; set; }
    public string LevelKey { get; set; }
}