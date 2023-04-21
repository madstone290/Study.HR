using Study.HR.Core.Domain;

namespace Study.HR.Core.Application.Base
{
    public static class RepositoryExtensions
    {
        public static async Task<TEntity> FindOrThrowAsync<TEntity, TId>(this IRepository<TEntity, TId> repository, TId id)
            where TEntity : Entity<TId>
            where TId : struct
        {
            TEntity? entity = await repository.FindAsync(id);
            return entity ?? throw new AppException($"개체를 찾을 수 없습니다. ID: {id}");
        }

        public static async Task<TEntity?> FindOrThrowAsync<TEntity, TId>(this IRepository<TEntity, TId> repository, TId? id)
           where TEntity : Entity<TId>
           where TId : struct
        {
            if (!id.HasValue)
                return null;

            TEntity? entity = await repository.FindAsync(id.Value);
            return entity ?? throw new AppException($"개체를 찾을 수 없습니다. ID: {id}");
        }


    }
}
