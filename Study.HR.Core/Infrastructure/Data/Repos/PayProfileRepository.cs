using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class PayProfileRepository : Repository<PayProfile>, IPayProfileReadRepository
    {
        public PayProfileRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PayProfileDto?> GetAsync(int salaryId)
        {
            return await Set
                .AsNoTracking()
                .Where(x => x.Id == salaryId)
                .Include(x => x.Employee)
                .Select(x => new PayProfileDto()
                {
                    EmployeeId = x.EmployeeId,
                    BaseSalary = x.BaseSalary,
                    BonusRate = x.BonusRate,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<PayProfileDto>> GetListAsync()
        {
            return await Set
               .AsNoTracking()
               .Include(x => x.Employee)
               .Select(x => new PayProfileDto()
               {
                   EmployeeId = x.EmployeeId,
                   BaseSalary = x.BaseSalary,
                   BonusRate = x.BonusRate,
               })
               .ToListAsync();
        }

        public async Task<List<PayProfileDto>> GetListAsync(int employeeId)
        {
            return await Set
               .AsNoTracking()
               .Where(x => x.EmployeeId == employeeId)
               .Include(x => x.Employee)
               .Select(x => new PayProfileDto()
               {
                   EmployeeId = x.EmployeeId,
                   BaseSalary = x.BaseSalary,
                   BonusRate = x.BonusRate,
               })
               .ToListAsync();
        }
    }
}
