using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Application.Commands.DepartmentCommands
{
    public class DeleteDepartmentCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteDepartmentCommandHandler : CommandHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public override async Task Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department department = await _repository.FindOrThrowAsync(command.Id);
            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }
    }
}

