using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Commands.JobPositionCmds
{
    public class DeleteJobPositionCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteJobPositionCommandHandler : ICommandHandler<DeleteJobPositionCommand>
    {
        private readonly IJobPositionRepository _repository;

        public DeleteJobPositionCommandHandler(IJobPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteJobPositionCommand request, CancellationToken cancellationToken)
        {
            var JobPosition = await _repository.FindOrThrowAsync(request.Id);
            _repository.Delete(JobPosition);
            await _repository.SaveChangesAsync();
        }

    }
}
