using Study.HR.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Repos
{
    public interface IJobRoleReadRepository
    { 
        /// <summary>
        /// 전체 직무 조회
        /// </summary>
        /// <returns></returns>
        Task<List<JobRoleDto>> GetListAsync();
    }
}
