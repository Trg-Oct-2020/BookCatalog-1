using BookCatalog.Domain.Abstractions;
using BookCatalog.Persistence.Generic.Abstractions;
using BookCatalog.Persistence.Persistence.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookCatalog.Infra.Persistence.EfCore.Repositories
{
    public class EfCoreRepository<TEntity, TContext> : IEfCoreRepository<TEntity> 
      where TContext : DbContext
      where TEntity : class, IEntity
    {
        public readonly TContext context;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public EfCoreRepository(TEntity entity, TContext context)
        {
            this.context = context;
        }

        protected DbSet<TEntity> DbSet => context.Set<TEntity>();

        public void DetachAll()
        {
            foreach (EntityEntry dbEntityEntry in context.ChangeTracker.Entries().ToArray())
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
        }

       
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(TEntity obj)
        {
            try
            {
                obj.CreatedDateTime= DateTime.UtcNow;
                await DbSet.AddAsync(obj);
                await context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

        }

        public async Task<bool> UpdateAsync(TEntity obj)
        {
            try
            {
                DetachAll();
                obj.UpdatedDateTime = DateTime.UtcNow;
                DbSet.Update(obj);
                await context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var obj = await GetById(id);
                if (obj == null)
                    return await Task.FromResult(false);
                DbSet.Remove(obj);
                await context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<TEntity> GetById(string id)
        {            
            return await Task.FromResult(DbSet.Find(id));
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {           
            return await Task.FromResult(DbSet.AsQueryable<TEntity>());
        }
    }
}
