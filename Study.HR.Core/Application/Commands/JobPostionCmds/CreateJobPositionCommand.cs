using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.JobPositionCmds
{
    public class CreateJobPositionCommand : ICommand<int>
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class CreateJobPositionCommandHandler : ICommandHandler<CreateJobPositionCommand, int>
    {
        private readonly IJobPositionRepository _repository;
        private readonly IJobPositionService _service;

        public CreateJobPositionCommandHandler(IJobPositionRepository repository, IJobPositionService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<int> Handle(CreateJobPositionCommand request, CancellationToken cancellationToken)
        {
            JobPosition jobPosition = await JobPosition.CreateAsync(request.Code, request.Name, _service);
            await _repository.AddAsync(jobPosition);
            await _repository.SaveChangesAsync();
            return jobPosition.Id;
        }
    }
}
