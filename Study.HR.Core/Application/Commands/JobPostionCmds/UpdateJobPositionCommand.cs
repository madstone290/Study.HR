using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.JobPositionCmds
{
    public class UpdateJobPositionCommand : ICommand
    {
        public int Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class UpdateJobPositionCommandHandler : ICommandHandler<UpdateJobPositionCommand>
    {
        private readonly IJobPositionRepository _repository;
        private readonly IJobPositionService _service;

        public UpdateJobPositionCommandHandler(IJobPositionRepository repository, IJobPositionService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task Handle(UpdateJobPositionCommand request, CancellationToken cancellationToken)
        {
            JobPosition JobPosition = await _repository.FindOrThrowAsync(request.Id);
            await JobPosition.ChangeCodeAsync(request.Code, _service);
            await JobPosition.ChangeNameAsync(request.Name, _service);

            await _repository.SaveChangesAsync();
        }

    }
}
