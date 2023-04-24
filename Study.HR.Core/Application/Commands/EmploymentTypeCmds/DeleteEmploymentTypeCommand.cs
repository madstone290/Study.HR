using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Commands.EmploymentTypeCmds
{
    public class DeleteEmploymentTypeCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteEmploymentCommandHandler : ICommandHandler<DeleteEmploymentTypeCommand>
    {
        private readonly IEmploymentTypeRepository _repository;

        public DeleteEmploymentCommandHandler(IEmploymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            EmploymentType employmentType = await _repository.FindOrThrowAsync(request.Id);
            _repository.Delete(employmentType);
            await _repository.SaveChangesAsync();
        }

    }
}
