using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Messaging.Mediator.Commands;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class ApproveEnrollmentHandler : ICommandHandler<ApproveEnrollment>
{
    private readonly IQueryEnrollmentRepository _queryRepository;
    private readonly ICommandEnrollmentRepository _commandRepository;
    private readonly IEnrollmentsUnitOfWork _unitOfWork;

    public ApproveEnrollmentHandler(
        IQueryEnrollmentRepository queryRepository,
        ICommandEnrollmentRepository commandRepository,
        IEnrollmentsUnitOfWork unitOfWork)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(ApproveEnrollment command, CancellationToken cancellationToken = default)
    {
        var enrollment = await _queryRepository.GetAsync(command.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound(nameof(Enrollment), command.EnrollmentId);

        enrollment.Approve();
        _commandRepository.Update(enrollment);
        var result = await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}