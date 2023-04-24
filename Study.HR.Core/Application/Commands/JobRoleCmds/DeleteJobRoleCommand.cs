using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Commands.JobRoleCmds
{
    public class DeleteJobRoleCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteJobRoleCommandHandler : ICommandHandler<DeleteJobRoleCommand>
    {
        private readonly IJobRoleRepository _repository;

        public DeleteJobRoleCommandHandler(IJobRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteJobRoleCommand request, CancellationToken cancellationToken)
        {
            var JobRole = await _repository.FindOrThrowAsync(request.Id);
            _repository.Delete(JobRole);
            await _repository.SaveChangesAsync();
        }

    }
}
