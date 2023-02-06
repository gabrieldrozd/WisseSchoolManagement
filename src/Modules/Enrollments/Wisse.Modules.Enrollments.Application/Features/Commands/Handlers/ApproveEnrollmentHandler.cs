using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Application.Events;
using Wisse.Modules.Enrollments.Application.Mappings.DTO;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;
using Wisse.Shared.Abstractions.Communication.Messaging;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class ApproveEnrollmentHandler : ICommandHandler<ApproveEnrollment>
{
    private readonly IQueryEnrollmentRepository _queryEnrollmentRepository;
    private readonly ICommandEnrollmentRepository _commandEnrollmentRepository;
    private readonly IEnrollmentsUnitOfWork _unitOfWork;
    private readonly IMessageBroker _messageBroker;

    public ApproveEnrollmentHandler(
        IQueryEnrollmentRepository queryEnrollmentRepository,
        ICommandEnrollmentRepository commandEnrollmentRepository,
        IEnrollmentsUnitOfWork unitOfWork,
        IMessageBroker messageBroker)
    {
        _queryEnrollmentRepository = queryEnrollmentRepository;
        _commandEnrollmentRepository = commandEnrollmentRepository;
        _unitOfWork = unitOfWork;
        _messageBroker = messageBroker;
    }

    public async Task<Result> HandleAsync(ApproveEnrollment command, CancellationToken cancellationToken = default)
    {
        var enrollment = await _queryEnrollmentRepository.GetDetailsAsync(command.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound(nameof(Enrollment), command.EnrollmentId);

        enrollment.Approve();
        _commandEnrollmentRepository.Update(enrollment);
        var result = await _unitOfWork.CommitAsync(cancellationToken);

        if (result.IsSuccess)
        {
            await _messageBroker.PublishAsync(new EnrollmentApproved(enrollment.ToEnrollmentDetailsDto()));
        }

        return result;
    }
}