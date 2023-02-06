namespace Wisse.Contracts.Enrollments.Approved.Contracts;

public class ApplicantDetailsContract
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public EducationContract Education { get; set; }
    public LanguageLevelContract LanguageLevel { get; set; }
}