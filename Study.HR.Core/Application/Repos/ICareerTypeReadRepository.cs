using Study.HR.Core.Application.Dto;

namespace Study.HR.Core.Application.Repos
{
    public interface ICareerTypeReadRepository    
    {
        /// <summary>
        /// 전체 경력타입 조회
        /// </summary>
        /// <returns></returns>
        Task<List<CareerTypeDto>> GetListAsync();
    }
}
