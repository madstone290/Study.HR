using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Domain;

namespace Study.HR.Core.Infrastructure.Data
{
    public static class RepositoryExtensions
    {
        public static Task<bool> ExistCodeAsync<TEntity, TId>(this DbSet<TEntity> set, string code)
            where TEntity : Entity<TId>, IHasCode
            where TId : struct
        {
            return set.AnyAsync(x => x.Code == code);
        }

        public static Task<bool> ExistNameAsync<TEntity, TId>(this DbSet<TEntity> set, string name)
            where TEntity : Entity<TId>, IHasName
            where TId : struct
        {
            return set.AnyAsync(x => x.Name == name);
        }

    }
}
