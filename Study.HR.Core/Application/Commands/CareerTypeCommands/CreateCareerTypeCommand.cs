using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.CareerTypeCommands
{
    public class CreateCareerTypeCommand : ICommand<int>
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class CreateCareerTypeCommandHandler : ICommandHandler<CreateCareerTypeCommand, int>
    {
        private readonly ICareerTypeRepository _repository;
        private readonly ICareerTypeService _service;

        public CreateCareerTypeCommandHandler(ICareerTypeRepository repository, ICareerTypeService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<int> Handle(CreateCareerTypeCommand request, CancellationToken cancellationToken)
        {
            var careerType = await CareerType.CreateAsync(request.Code, request.Name, _service);
            await _repository.AddAsync(careerType);
            await _repository.SaveChangesAsync();
            return careerType.Id;
        }
    }
}
