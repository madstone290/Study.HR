using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

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

        public UpdateCareerTypeCommandHandler(ICareerTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCareerTypeCommand request, CancellationToken cancellationToken)
        {
            var careerType = await _repository.FindOrThrowAsync(request.Id);
            careerType.ChangeCode(request.Code);
            careerType.ChangeName(request.Name);

            await _repository.SaveChangesAsync();
        }

    }
}
