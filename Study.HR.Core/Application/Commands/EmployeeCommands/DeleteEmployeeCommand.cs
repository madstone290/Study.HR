using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Application.Commands.EmployeeCommands
{
    public class DeleteEmployeeCommand : ICommand
    {
        public int Id { get; init; }
    }

    public class DeleteEmploymentCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmploymentCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _repository.FindOrThrowAsync(request.Id);
            _repository.Delete(employee);
            await _repository.SaveChangesAsync();
        }

    }
}
