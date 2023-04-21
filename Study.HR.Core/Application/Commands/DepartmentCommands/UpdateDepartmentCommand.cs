using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.DepartmentCommands
{
    public class UpdateDepartmentCommand : ICommand
    {
        public int Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public int? UpperDepartmentId { get; init; }
    }

    public class UpdateDepartmentCommandHandler : CommandHandler<UpdateDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IDepartmentService _service;

        public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IDepartmentService service)
        {
            _repository = repository;
            _service = service;
        }

        public override async Task Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department department = await _repository.FindOrThrowAsync(command.Id);
            await department.ChangeCodeAsync(command.Code, _service);
            await department.ChangeNameAsync(command.Name, _service);

            Department? upperDepartment = await _repository.FindOrThrowAsync(command.UpperDepartmentId);
            department.ChangeUpperDepartment(upperDepartment);

            await _repository.SaveChangesAsync();
        }
    }
}

