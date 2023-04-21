using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository, IDepartmentReadRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> ExistCodeAsync(string code)
        {
            return Set.AnyAsync(x=> x.Code == code);
        }

        public Task<bool> ExistNameAsync(string name)
        {
            return Set.AnyAsync(x => x.Name == name);
        }

        public Task<List<DepartmentDto>> GetListAsync()
        {
            return Set.SelectDepartmentDto().ToListAsync();
        }
    }

    public static class DepartmentRepositoryExtensions
    {
        public static IQueryable<DepartmentDto> SelectDepartmentDto(this IQueryable<Department> query)
        {
            return query.Select(x => new DepartmentDto()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                UpperDepartmentId = x.UpperDepartmentId
            });
        }
    }
}
