using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

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

        public CreateCareerTypeCommandHandler(ICareerTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCareerTypeCommand request, CancellationToken cancellationToken)
        {
            var careerType = new CareerType(request.Code, request.Name);
            await _repository.AddAsync(careerType);
            await _repository.SaveChangesAsync();
            return careerType.Id;
        }
    }
}
