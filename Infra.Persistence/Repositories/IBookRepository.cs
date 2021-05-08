using BookCatalog.Domain.Entities;
using System.Linq;

namespace BookCatalog.Infra.Persistence.Repositories
{
    public interface IBookRepository
    {
        public IQueryable<Book> GetAll();
        public IQueryable<Book> Add(Book book);
        public IQueryable<Book> Update(Book book);
        public string Delete(string id);
        public IQueryable<Book> Get(string title, string author, string isbn);
    }
}
