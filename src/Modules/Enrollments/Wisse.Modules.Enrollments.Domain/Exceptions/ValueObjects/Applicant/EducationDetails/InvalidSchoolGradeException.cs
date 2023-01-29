using Wisse.Common.Exceptions;
using Wisse.Modules.Enrollments.Domain.Constants;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.EducationDetails;

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