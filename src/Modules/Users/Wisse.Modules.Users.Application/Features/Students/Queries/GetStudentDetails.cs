using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;
using Wisse.Modules.Users.Application.DTO.Queries.Student;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Features.Students.Queries;

[QueryEntityName(typeof(Student))]
public record GetStudentDetails(Guid StudentId) : IQuery<StudentDetailsDto>;