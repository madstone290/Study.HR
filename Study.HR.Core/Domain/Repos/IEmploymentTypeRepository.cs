using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface IEmploymentTypeRepository : IRepositoryBase<EmploymentType>, ICodeRepository, INameRepository
    {
    }
}
