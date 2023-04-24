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
    public class EmploymentTypeRepository : Repository<EmploymentType>, IEmploymentTypeRepository, IEmploymentTypeReadRepository
    {
        public EmploymentTypeRepository(ApplicationDbContext context) : base(context)
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

        public Task<List<EmploymentTypeDto>> GetListAsync()
        {
            return Set.SelectEmploymentTypeDto().ToListAsync();
        }
    }

    public static class EmploymentTypeRepositoryExtensions
    {
        public static IQueryable<EmploymentTypeDto> SelectEmploymentTypeDto(this IQueryable<EmploymentType> query)
        {
            return query.Select(x => new EmploymentTypeDto()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
            });
        }
    }
}
