using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.EmploymentTypeCmds
{
    public class UpdateEmploymentTypeCommand : ICommand
    {
        public int Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class UpdateEmploymentCommandHandler : ICommandHandler<UpdateEmploymentTypeCommand>
    {
        private readonly IEmploymentTypeRepository _repository;
        private readonly IEmploymentTypeService _service;

        public UpdateEmploymentCommandHandler(IEmploymentTypeRepository repository, IEmploymentTypeService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task Handle(UpdateEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            EmploymentType employmentType = await _repository.FindOrThrowAsync(request.Id);
            await employmentType.ChangeCodeAsync(request.Code, _service);
            await employmentType.ChangeNameAsync(request.Name, _service);

            await _repository.SaveChangesAsync();
        }

    }
}
