using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class JobRoleRepository : Repository<JobRole>, IJobRoleRepository, IJobRoleReadRepository
    {
        public JobRoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> ExistCodeAsync(string code)
        {
            return Set.AnyAsync(x => x.Code == code);
        }

        public Task<bool> ExistNameAsync(string name)
        {
            return Set.AnyAsync(x => x.Name == name);
        }

        public Task<List<JobRoleDto>> GetListAsync()
        {
            return Set.SelectJobRolenDto().ToListAsync();
        }
    }

    public static class JobRoleRepositoryExtensions
    {
        public static IQueryable<JobRoleDto> SelectJobRolenDto(this IQueryable<JobRole> query)
        {
            return query.Select(x => new JobRoleDto()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
            });
        }
    }
}
