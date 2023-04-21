using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Domain.Services
{
    public interface IDepartmentService : IDomainService
    {
        Task<bool> CodeExistAsync(string code);

        Task<bool> NameExistAsync(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CodeExistAsync(string code)
        {
            return _repository.ExistCodeAsync(code);
        }

        public Task<bool> NameExistAsync(string name)
        {
            return _repository.ExistNameAsync(name);
        }
    }
}
