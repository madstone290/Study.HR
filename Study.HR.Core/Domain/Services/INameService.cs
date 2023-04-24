namespace Study.HR.Core.Domain.Services
{
    public interface INameService : IDomainService
    {
        Task<bool> NameExistAsync(string name);
    }
}
