using BookCatalog.Domain.Abstractions;
using System.Linq;

namespace BookCatalog.MicroService.Domain.Abstractions
{
    // public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> Add(TEntity obj);
        public IQueryable<TEntity> Update(TEntity obj);
        public string Delete(string id);        
    }
}
