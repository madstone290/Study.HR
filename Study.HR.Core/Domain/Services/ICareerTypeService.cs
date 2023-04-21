using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Domain.Services
{
    public interface ICareerTypeService : IDomainService
    {
        Task<bool> CodeExistsAsync(string code);

        Task<bool> NameExists(string name);
    }

    public class CareerTypeService : ICareerTypeService
    {
        private readonly ICareerTypeRepository _repository;

        public CareerTypeService(ICareerTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CodeExistsAsync(string code)
        {
            return _repository.ExistCodeAsync(code);
        }

        public Task<bool> NameExists(string name)
        {
            return _repository.ExistNameAsync(name);
        }

    }
}
