using Wisse.Base.Types;

namespace Wisse.Modules.Enrollments.Domain.Constants;

public class Education : CollectionEnumeration<Education, string>
{
    public static readonly Education Elementary = new ElementaryEducation();
    public static readonly Education HighSchool = new HighSchoolEducation();
    public static readonly Education TechnicalSchool = new TechnicalSchoolEducation();
    public static readonly Education University = new UniversityEducation();
    public static readonly Education Finished = new FinishedEducation();

    private Education(int value, string name, string[] collection)
        : base(value, name, collection)
    {
    }

    public static bool IsSchoolValid(string school)
    {
        return FromName(school) is not null;
    }

    public static bool IsGradeValid(string school, string grade)
    {
        var schoolGrades = FromName(school).Collection;
        return schoolGrades.Contains(grade);
    }

    private sealed class ElementaryEducation : Education
    {
        private const string SchoolName = "Elementary";
        private static readonly string[] SchoolGrades = { "Preschool", "1", "2", "3", "4", "5", "6", "7", "8" };

        public ElementaryEducation()
            : base(1, SchoolName, SchoolGrades)
        {
        }
    }

    private sealed class HighSchoolEducation : Education
    {
        private const string SchoolName = "High School";
        private static readonly string[] SchoolGrades = { "1", "2", "3", "4" };

        public HighSchoolEducation()
            : base(2, SchoolName, SchoolGrades)
        {
        }
    }

    private sealed class TechnicalSchoolEducation : Education
    {
        private const string SchoolName = "Technical School";
        private static readonly string[] SchoolGrades = { "1", "2", "3", "4", "5" };

        public TechnicalSchoolEducation()
            : base(3, SchoolName, SchoolGrades)
        {
        }
    }

    private sealed class UniversityEducation : Education
    {
        private const string SchoolName = "University";
        private static readonly string[] SchoolGrades = { "None" };

        public UniversityEducation()
            : base(4, SchoolName, SchoolGrades)
        {
        }
    }

    private sealed class FinishedEducation : Education
    {
        private const string SchoolName = "Finished";
        private static readonly string[] SchoolGrades = { "None" };

        public FinishedEducation()
            : base(5, SchoolName, SchoolGrades)
        {
        }
    }
}