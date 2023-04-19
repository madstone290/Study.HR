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
    public class EmployeeSalaryReadRepository : Repository<EmployeeSalary>, IEmployeeSalaryReadRepository
    {
        public EmployeeSalaryReadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<EmployeeSalaryDto?> GetAsync(int salaryId)
        {
            return await Entities
                .AsNoTracking()
                .Where(x => x.Id == salaryId)
                .Include(x => x.Employee)
                .Select(x => new EmployeeSalaryDto()
                {
                    EmployeeId = x.EmployeeId,
                    BaseSalary = x.BaseSalary,
                    BonusRate = x.BonusRate,
                    EmployeeEnteredDate = x.Employee.EnteredDate,
                    EmployeeName = x.Employee.Name,
                    ValidAfter = x.ValidAfter,
                    ValidBefore = x.ValidBefore,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<EmployeeSalaryDto>> GetListAsync()
        {
            return await Entities
               .AsNoTracking()
               .Include(x => x.Employee)
               .Select(x => new EmployeeSalaryDto()
               {
                   EmployeeId = x.EmployeeId,
                   BaseSalary = x.BaseSalary,
                   BonusRate = x.BonusRate,
                   EmployeeEnteredDate = x.Employee.EnteredDate,
                   EmployeeName = x.Employee.Name,
                   ValidAfter = x.ValidAfter,
                   ValidBefore = x.ValidBefore,
               })
               .ToListAsync();
        }

        public async Task<List<EmployeeSalaryDto>> GetListAsync(int employeeId)
        {
            return await Entities
               .AsNoTracking()
               .Where(x => x.EmployeeId == employeeId)
               .Include(x => x.Employee)
               .Select(x => new EmployeeSalaryDto()
               {
                   EmployeeId = x.EmployeeId,
                   BaseSalary = x.BaseSalary,
                   BonusRate = x.BonusRate,
                   EmployeeEnteredDate = x.Employee.EnteredDate,
                   EmployeeName = x.Employee.Name,
                   ValidAfter = x.ValidAfter,
                   ValidBefore = x.ValidBefore,
               })
               .ToListAsync();
        }
    }
}
