using Study.HR.Core.Application.Dto;

namespace Study.HR.Core.Application.Repos
{
    public interface IDepartmentReadRepository
    {
        /// <summary>
        /// 전체 부서 조회
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentDto>> GetListAsync();
    }
}
