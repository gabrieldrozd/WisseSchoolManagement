using Wisse.Common.Domain.Constants;

namespace Wisse.Common.Exceptions.ValueObjects;

public class InvalidSchoolGradeException : DomainException
{
    public InvalidSchoolGradeException(string school, string grade)
        : base($"""
Invalid grade '{grade}' for {school}. Valid grades are:
{string.Join(", ", Education.FromName(school).Collection.Select(x => x))}
""")
    {
    }
}