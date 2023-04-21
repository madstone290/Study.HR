using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Domain;
using System.Linq.Expressions;

namespace Study.HR.Core.Infrastructure.Data
{
    public abstract class Repository
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }


    public class Repository<TEntity> : Repository<TEntity, int>
        where TEntity : Entity<int>
    {
        public Repository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class Repository<TEntity, TId> : Repository, IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        public Repository(ApplicationDbContext context) : base(context)
        {
        }

        public IUnitOfWork UnitOfWork => _context;
        public DbSet<TEntity> Set => _context.Set<TEntity>();
        public ApplicationDbContext Context => _context;

        public async ValueTask AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .ToListAsync();
        }


        public async Task<TEntity?> FindAsync(TId id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }




}
