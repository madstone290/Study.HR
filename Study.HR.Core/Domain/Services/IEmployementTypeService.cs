using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Domain.Services
{
    public interface IEmploymentTypeService : IDomainService
    {
        Task<bool> CodeExistAsync(string code);

        Task<bool> NameExistAsync(string name);
    }

    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IEmploymentTypeRepository _repository;

        public EmploymentTypeService(IEmploymentTypeRepository repository)
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
