using Study.HR.Core.Application.Dto;

namespace Study.HR.Core.Application.Repos
{
    public interface IEmployeeReadRepository
    {
        /// <summary>
        /// 전체 직원 조회
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDto>> GetListAsync();
    }
}
