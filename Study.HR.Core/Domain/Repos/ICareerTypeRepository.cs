using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface ICareerTypeRepository : IRepositoryBase<CareerType>, ICodeRepository, INameRepository
    {
    }
}
