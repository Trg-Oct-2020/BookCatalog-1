using BookCatalog.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Infra.Persistence.Repositories
{
    public interface IBookRepository
    {
        Task<IQueryable<Book>> GetAll();

        Task<bool> AddAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(string id);
        Task<IQueryable<Book>> Get(string title, string author, string isbn);
        Task<Book> GetById(string id);
    }
}
