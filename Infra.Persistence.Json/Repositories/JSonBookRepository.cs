using BookCatalog.Domain.Entities;
using BookCatalog.Infra.Persistence.Repositories;
using System.Linq;

namespace BookCatalog.Infra.Persistence.Json.Repositories
{
    public class JSonBookRepository: JsonRepository<Book> , IBookRepository
    {
        public IQueryable<Book> Get(string title, string author, string isbn)
        {
            var query = ReadData.AsQueryable();
            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.title == title).AsQueryable();
            if (!string.IsNullOrEmpty(author))
                query = query.Where(x => x.author == author).AsQueryable();
            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(x => x.isbn == isbn).AsQueryable();
            return query;
        }
    }
}
