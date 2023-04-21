using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.DepartmentCommands
{
    public class CreateDepartmentCommand : ICommand<int>
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public int? UpperDepartmentId { get; init; }
    }

    public class CreateDepartmentCommandHandler : CommandHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IDepartmentService _service;

        public CreateDepartmentCommandHandler(IDepartmentRepository repository, IDepartmentService service)
        {
            _repository = repository;
            _service = service;
        }

        public override async Task<int> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department department = await Department.CreateAsync(command.Code, command.Name, _service);
            Department? upperDepartment = await _repository.FindOrThrowAsync(command.UpperDepartmentId);
            department.ChangeUpperDepartment(upperDepartment);

            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
            return department.Id;
        }
    }
}

