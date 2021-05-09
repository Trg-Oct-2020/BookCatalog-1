using BookCatalog.Domain.Abstractions;
using BookCatalog.Persistence.Generic.Abstractions;

namespace BookCatalog.Infra.Persistence.Json.Repositories
{
    public interface IJsonRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IEntity
    {
    }
}
