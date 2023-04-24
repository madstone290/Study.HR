using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.JobRoleCmds
{
    public class CreateJobRoleCommand : ICommand<int>
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class CreateJobRoleCommandHandler : ICommandHandler<CreateJobRoleCommand, int>
    {
        private readonly IJobRoleRepository _repository;
        private readonly IJobRoleService _service;

        public CreateJobRoleCommandHandler(IJobRoleRepository repository, IJobRoleService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<int> Handle(CreateJobRoleCommand request, CancellationToken cancellationToken)
        {
            JobRole jobRole = await JobRole.CreateAsync(request.Code, request.Name, _service);
            await _repository.AddAsync(jobRole);
            await _repository.SaveChangesAsync();
            return jobRole.Id;
        }
    }
}
