using Wisse.Contracts.Enrollments.Approved.Contracts;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Application.Mappings.Contract;

public static class ApplicantContractMappings
{
    public static ApplicantDetailsContract ToContract(this Applicant model)
        => new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate.ToDateTime(),
            Education = new EducationContract
            {
                School = model.EducationDetails.School,
                Grade = model.EducationDetails.Grade,
            },
            LanguageLevel = new LanguageLevelContract
            {
                Key = model.LanguageLevel.Key,
                Name = model.LanguageLevel.Name
            }
        };
}