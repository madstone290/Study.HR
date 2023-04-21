using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Commands.CareerTypeCommands
{
    public class DeleteCareerTypeCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteCareerTypeCommandHandler : ICommandHandler<DeleteCareerTypeCommand>
    {
        private readonly ICareerTypeRepository _repository;

        public DeleteCareerTypeCommandHandler(ICareerTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCareerTypeCommand request, CancellationToken cancellationToken)
        {
            var careerType = await _repository.FindOrThrowAsync(request.Id);
            _repository.Delete(careerType);
            await _repository.SaveChangesAsync();
        }

    }
}
