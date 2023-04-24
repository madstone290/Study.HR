using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Domain.Services
{
    public interface IDepartmentService : IDomainService, ICodeService, INameService
    {
    }
}
