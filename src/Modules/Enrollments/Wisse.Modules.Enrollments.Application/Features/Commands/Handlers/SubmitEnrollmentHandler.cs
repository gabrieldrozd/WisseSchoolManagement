using Wisse.Common.Results;
using Wisse.Modules.Enrollments.Domain.Repositories;
using Wisse.Shared.Abstractions.Mediator.Commands;

namespace Wisse.Modules.Enrollments.Application.Features.Commands.Handlers;

internal sealed class SubmitEnrollmentHandler : ICommandHandler<SubmitEnrollment>
{
    private readonly ICommandEnrollmentRepository _repository;

    public SubmitEnrollmentHandler(ICommandEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public Task<Result> HandleAsync(SubmitEnrollment command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
