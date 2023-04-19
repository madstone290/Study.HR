using Study.HR.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Repos
{
    public interface IEmployeeSalaryReadRepository
    {
        Task<List<EmployeeSalaryDto>> GetListAsync();

        Task<List<EmployeeSalaryDto>> GetListAsync(int employeeId);

        Task <EmployeeSalaryDto?> GetAsync(int salaryId);
    }
}
