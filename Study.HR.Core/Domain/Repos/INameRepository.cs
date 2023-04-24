namespace Study.HR.Core.Domain.Repos
{
    public interface INameRepository
    {
        /// <summary>
        /// 이름 중복확인
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> ExistNameAsync(string name);
    }
}
