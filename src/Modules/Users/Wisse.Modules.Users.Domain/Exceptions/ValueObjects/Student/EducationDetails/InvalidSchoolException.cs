using Wisse.Common.Exceptions;
using Wisse.Modules.Users.Domain.Constants;

namespace Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.EducationDetails;

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