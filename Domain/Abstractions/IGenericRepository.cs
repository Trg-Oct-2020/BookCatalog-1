using BookCatalog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Domain.Abstractions
{
    // public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {        
       
        Task<TEntity> GetById(string id);
        //Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        //IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<IQueryable<TEntity>> GetAll();

        Task<bool> AddAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(string id);
    }
}
