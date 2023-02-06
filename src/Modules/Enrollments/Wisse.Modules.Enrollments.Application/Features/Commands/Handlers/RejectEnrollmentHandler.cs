using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class RejectEnrollmentHandler : ICommandHandler<RejectEnrollment>
{
    private readonly IQueryEnrollmentRepository _queryEnrollmentRepository;
    private readonly ICommandEnrollmentRepository _commandEnrollmentRepository;
    private readonly IEnrollmentsUnitOfWork _unitOfWork;

    public RejectEnrollmentHandler(
        IQueryEnrollmentRepository queryEnrollmentRepository,
        ICommandEnrollmentRepository commandEnrollmentRepository,
        IEnrollmentsUnitOfWork unitOfWork)
    {
        _queryEnrollmentRepository = queryEnrollmentRepository;
        _commandEnrollmentRepository = commandEnrollmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(RejectEnrollment command, CancellationToken cancellationToken = default)
    {
        var enrollment = await _queryEnrollmentRepository.GetAsync(command.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound(nameof(Enrollment), command.EnrollmentId);

        enrollment.Reject();
        _commandEnrollmentRepository.Update(enrollment);
        var result = await _unitOfWork.CommitAsync(cancellationToken);
        
        return result;
    }
}