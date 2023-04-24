using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>, ICodeRepository
    {
    }
}
