using BookCatalog.Domain.Abstractions;
using BookCatalog.Persistence.Generic.Abstractions;

namespace BookCatalog.Persistence.Persistence.EfCore.Repositories
{
    public interface IEfCoreRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IEntity
    {
    }
}
