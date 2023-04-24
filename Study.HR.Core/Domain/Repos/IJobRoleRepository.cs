using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface IJobRoleRepository : IRepositoryBase<JobRole>, ICodeRepository, INameRepository
    {
    }
}
