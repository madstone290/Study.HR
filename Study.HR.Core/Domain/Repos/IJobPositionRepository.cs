using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface IJobPositionRepository : IRepositoryBase<JobPosition>, ICodeRepository, INameRepository
    {
    }
}
