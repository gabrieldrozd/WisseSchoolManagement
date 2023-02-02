using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Application.Notices;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;
using Wisse.Shared.Abstractions.Communication.Messaging;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class ApproveEnrollmentHandler : ICommandHandler<ApproveEnrollment>
{
    private readonly IQueryEnrollmentRepository _queryRepository;
    private readonly ICommandEnrollmentRepository _commandRepository;
    private readonly IEnrollmentsUnitOfWork _unitOfWork;
    private readonly IMessageBroker _messageBroker;

    public ApproveEnrollmentHandler(
        IQueryEnrollmentRepository queryRepository,
        ICommandEnrollmentRepository commandRepository,
        IEnrollmentsUnitOfWork unitOfWork,
        IMessageBroker messageBroker)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
        _messageBroker = messageBroker;
    }

    public async Task<Result> HandleAsync(ApproveEnrollment command, CancellationToken cancellationToken = default)
    {
        var enrollment = await _queryRepository.GetDetailsAsync(command.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound(nameof(Enrollment), command.EnrollmentId);

        enrollment.Approve();
        _commandRepository.Update(enrollment);
        var result = await _unitOfWork.CommitAsync(cancellationToken);

        if (result.IsSuccess)
        {
            await _messageBroker.PublishAsync(new EnrollmentApproved(enrollment.ToEnrollmentDetailsDto()));
        }

        return result;
    }
}