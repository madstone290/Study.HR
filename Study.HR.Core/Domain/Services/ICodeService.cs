namespace Study.HR.Core.Domain.Services
{
    public interface ICodeService : IDomainService
    {
        Task<bool> CodeExistAsync(string code);
    }
}
