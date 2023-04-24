using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain
{
    public interface IRepositoryBase<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TEntity?> FindAsync(TId id);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IUnitOfWork UnitOfWork { get; }
        Task SaveChangesAsync();
    }

    public interface IRepositoryBase<TEntity> : IRepositoryBase<TEntity, int>
         where TEntity : Entity<int>
    {

    }
}
