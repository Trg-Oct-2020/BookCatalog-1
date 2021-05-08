using BookCatalog.Domain.Abstractions;
using BookCatalog.MicroService.Domain.Abstractions;

namespace BookCatalog.Infra.Data.Repositories
{
    public interface IJsonRepository<TEntity>: IGenericRepository<TEntity> where TEntity: IEntity
    {
    }
}
