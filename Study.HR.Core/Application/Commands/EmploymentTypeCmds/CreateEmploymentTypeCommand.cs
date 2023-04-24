using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.EmploymentTypeCmds
{
    public class CreateEmploymentTypeCommand : ICommand<int>
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }

    public class CreateEmploymentCommandHandler : ICommandHandler<CreateEmploymentTypeCommand, int>
    {
        private readonly IEmploymentTypeRepository _repository;
        private readonly IEmploymentTypeService _service;

        public CreateEmploymentCommandHandler(IEmploymentTypeRepository repository, IEmploymentTypeService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<int> Handle(CreateEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            EmploymentType employmentType = await EmploymentType.CreateAsync(request.Code, request.Name, _service);
            await _repository.AddAsync(employmentType);
            await _repository.SaveChangesAsync();
            return employmentType.Id;
        }
    }
}
