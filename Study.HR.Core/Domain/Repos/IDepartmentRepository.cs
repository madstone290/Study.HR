using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Domain.Repos
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<bool> ExistCodeAsync(string code);

        Task<bool> ExistNameAsync(string name);
    }
}
