using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;

public class EducationDetails : ValueObject
{
    public string School { get; }
    public string Grade { get; }

    public EducationDetails(string school, string grade)
    {
        if (string.IsNullOrWhiteSpace(school) || string.IsNullOrWhiteSpace(grade))
        {
            throw new EmptyEducationDetailsException();
        }

        if (!Education.IsSchoolValid(school))
        {
            throw new InvalidSchoolException(school);
        }

        if (!Education.IsGradeValid(school, grade))
        {
            throw new InvalidSchoolGradeException(school, grade);
        }

        School = school;
        Grade = grade;
    }

    public static EducationDetails Create(Education education, string grade)
        => new(education.Name, grade);

    public static EducationDetails FromString(string schoolAndGrade)
        => new(schoolAndGrade.Split(',')[0], schoolAndGrade.Split(',')[1]);

    public override string ToString() => $"{School},{Grade}";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return School;
        yield return Grade;
    }
}