using BookCatalog.Application.Repositories;
using BookCatalog.Domain.Entities;
using BookCatalog.MicroService.Infra.Persistence.EfCore.Context;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Infra.Persistence.EfCore.Repositories
{
    //public class EfCoreBookRepository : EfCoreRepository<Book, BookContext>, IBookRepository
    //{
    //    public async Task<IQueryable<Book>> Get(string title, string author, string isbn)
    //    {
    //        var query = DbSet.AsQueryable();
    //        if (!string.IsNullOrEmpty(title))
    //            query = query.Where(x => x.title == title).AsQueryable();
    //        if (!string.IsNullOrEmpty(author))
    //            query = query.Where(x => x.author == author).AsQueryable();
    //        if (!string.IsNullOrEmpty(isbn))
    //            query = query.Where(x => x.isbn == isbn).AsQueryable();
    //        return await Task.FromResult(query);
    //    }
    //}
}
