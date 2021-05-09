using BookCatalog.Domain.Abstractions;
using BookCatalog.MicroService.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookCatalog.Infra.Data.Repositories
{
    public class EfCoreRepository<TEntity, TContext> : IGenericRepository<TEntity>
      where TContext : DbContext
      where TEntity : class, IEntity
    {
        public readonly TContext context;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public List<TEntity> FindWhere(Func<TEntity, bool> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            DetachAll();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
            return entity;
        }

        public void DetachAll()
        {
            foreach (EntityEntry dbEntityEntry in context.ChangeTracker.Entries().ToArray())
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsQueryable<TEntity>();
        }

        //public IQueryable<TEntity> Add(TEntity obj)
        //{
        //    context.Set<TEntity>().Add(obj);
        //    context.SaveChanges();
        //    return GetAll();
        //}

        //public IQueryable<TEntity> Update(TEntity obj)
        //{
        //    DetachAll();
        //    context.Set<TEntity>().Update(obj);
        //    context.SaveChanges();
        //    return GetAll();
        //}

        public string Delete(string id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return id;
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return id;
        }



        public TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }



        public Task<bool> AddAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IGenericRepository<TEntity>.GetById(string id)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<TEntity>> IGenericRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
