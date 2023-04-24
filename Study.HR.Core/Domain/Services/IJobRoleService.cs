using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Domain.Services
{
    public interface IJobRoleService : IDomainService
    {
        Task<bool> CodeExistAsync(string code);

        Task<bool> NameExistAsync(string name);
    }

    public class JobRoleService : IJobRoleService
    {
        private readonly IJobRoleRepository _repository;

        public JobRoleService(IJobRoleRepository repository)
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
