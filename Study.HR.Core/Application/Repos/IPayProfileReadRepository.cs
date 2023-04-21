using Study.HR.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Repos
{
    public interface IPayProfileReadRepository
    {
        Task<List<PayProfileDto>> GetListAsync();

        Task<List<PayProfileDto>> GetListAsync(int employeeId);

        Task <PayProfileDto?> GetAsync(int payProfileId);
    }
}
