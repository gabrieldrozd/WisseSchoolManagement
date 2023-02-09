using Wisse.Common.Domain.Constants;

namespace Wisse.Common.Exceptions.ValueObjects.EducationDetails;

public class InvalidSchoolException : DomainException
{
    public InvalidSchoolException(string school)
        : base($"""
Invalid school: {school}. Valid schools are:
{Education.Elementary.Name},
{Education.HighSchool.Name},
{Education.TechnicalSchool.Name},
{Education.University.Name},
{Education.Finished.Name}.
""")
    {
    }
}