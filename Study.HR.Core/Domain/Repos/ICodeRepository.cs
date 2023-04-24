namespace Study.HR.Core.Domain.Repos
{
    public interface ICodeRepository
    {
        /// <summary>
        /// 코드 중복확인
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> ExistCodeAsync(string code);
    }
}
