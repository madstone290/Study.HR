using Study.HR.Core.Application.Dto;

namespace Study.HR.Core.Application.Repos
{
    public interface IEmploymentTypeReadRepository
    {
        /// <summary>
        /// 전체 고용유형 조회
        /// </summary>
        /// <returns></returns>
        Task<List<EmploymentTypeDto>> GetListAsync();
    }
}
