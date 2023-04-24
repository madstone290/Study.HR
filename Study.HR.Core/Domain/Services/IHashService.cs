namespace Study.HR.Core.Domain.Services
{
    public interface IHashService : IDomainService
    {
        string Hash(string value);
    }
}
