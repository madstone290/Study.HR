﻿using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Domain;
using Study.HR.Core.Domain.Repos;
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
        public DbSet<TEntity> Entities => _context.Set<TEntity>();
        public ApplicationDbContext Context => _context;

        public async ValueTask AddAsync(TEntity entity, bool commit = true)
        {
            await _context.AddAsync(entity);
            if(commit)
                await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .ToListAsync();
        }


        public async Task<TEntity?> GetAsync(TId id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }




}
