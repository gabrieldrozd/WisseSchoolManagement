namespace Wisse.Modules.Enrollments.Application.DTO.Applicant.Response;

public class ApplicantDetailsDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public EducationDto Education { get; set; }
    public LanguageLevelDto LanguageLevel { get; set; }
}