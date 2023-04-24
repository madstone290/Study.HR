using Study.HR.Core.Application.Dto;

namespace Study.HR.Core.Application.Repos
{
    public interface IJobPositionReadRepository    
    {
        /// <summary>
        /// 전체 직위 조회
        /// </summary>
        /// <returns></returns>
        Task<List<JobPositionDto>> GetListAsync();
    }
}
