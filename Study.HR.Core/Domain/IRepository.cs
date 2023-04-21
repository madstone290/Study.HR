using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain
{
    public interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TEntity?> GetAsync(TId id);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
         where TEntity : Entity<int>
    {

    }
}
