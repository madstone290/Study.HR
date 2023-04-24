using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.JobRoleCommands
{
    public class UpdateJobRoleCommand : ICommand
    {
        public int Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class UpdateJobRoleCommandHandler : ICommandHandler<UpdateJobRoleCommand>
    {
        private readonly IJobRoleRepository _repository;
        private readonly IJobRoleService _service;

        public UpdateJobRoleCommandHandler(IJobRoleRepository repository, IJobRoleService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task Handle(UpdateJobRoleCommand request, CancellationToken cancellationToken)
        {
            JobRole JobRole = await _repository.FindOrThrowAsync(request.Id);
            await JobRole.ChangeCodeAsync(request.Code, _service);
            await JobRole.ChangeNameAsync(request.Name, _service);

            await _repository.SaveChangesAsync();
        }

    }
}
