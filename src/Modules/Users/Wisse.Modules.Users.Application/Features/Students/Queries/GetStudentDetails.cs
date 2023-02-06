using Wisse.Common.Communication.Internal;
using Wisse.Modules.Users.Application.DTO.Queries.Student;

namespace Wisse.Modules.Users.Application.Features.Students.Queries;

public record GetStudentDetails(Guid StudentId) : IQuery<StudentDetailsDto>;