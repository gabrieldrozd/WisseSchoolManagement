using Wisse.Common.Exceptions;
using Wisse.Modules.Users.Domain.Constants;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.EducationDetails;

internal class InvalidSchoolGradeException : DomainException
{
    public InvalidSchoolGradeException(string school, string grade)
        : base($"""
Invalid grade '{grade}' for {school}. Valid grades are:
{string.Join(", ", Education.FromName(school).Collection.Select(x => x))}
""")
    {
    }
}