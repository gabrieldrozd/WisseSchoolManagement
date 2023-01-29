using Wisse.Common.Exceptions;
using Wisse.Modules.Enrollments.Domain.Constants;

namespace Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.EducationDetails;

internal class InvalidSchoolException : DomainException
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