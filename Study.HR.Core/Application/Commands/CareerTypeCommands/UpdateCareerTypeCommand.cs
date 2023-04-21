using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.CareerTypeCommands
{
    public class UpdateCareerTypeCommand : ICommand
    {
        public int Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class UpdateCareerTypeCommandHandler : ICommandHandler<UpdateCareerTypeCommand>
    {
        private readonly ICareerTypeRepository _repository;
        private readonly ICareerTypeService _service;

        public UpdateCareerTypeCommandHandler(ICareerTypeRepository repository, ICareerTypeService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task Handle(UpdateCareerTypeCommand request, CancellationToken cancellationToken)
        {
            CareerType careerType = await _repository.FindOrThrowAsync(request.Id);
            await careerType.ChangeCodeAsync(request.Code, _service);
            await careerType.ChangeNameAsync(request.Name, _service);

            await _repository.SaveChangesAsync();
        }

    }
}
