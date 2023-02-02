using Wisse.Base.Results;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Modules.Enrollments.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class SubmitEnrollmentHandler : ICommandHandler<SubmitEnrollment>
{
    private readonly ICommandEnrollmentRepository _repository;
    private readonly IEnrollmentsUnitOfWork _unitOfWork;

    public SubmitEnrollmentHandler(
        ICommandEnrollmentRepository repository,
        IEnrollmentsUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(SubmitEnrollment command, CancellationToken cancellationToken = default)
    {
        var enrollment = Enrollment.Create(command.Enrollment.Id, Date.Now);

        var applicant = Applicant.Create(command.Enrollment.Applicant.ToDefinition());
        enrollment.SetApplicant(applicant);

        var contact = Contact.Create(command.Enrollment.Contact.ToDefinition());
        enrollment.SetContact(contact);

        _repository.Insert(enrollment);
        var result = await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}