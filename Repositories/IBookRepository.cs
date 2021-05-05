using BookCatalog.MicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Repositories
{
    public interface IBookRepository
    {
        public IQueryable<Book> GetBook();
        public IQueryable<Book> AddBook(Book book);
        public IQueryable<Book> UpdateBook(Book book);
        public string DeleteBook(string id);
        public IQueryable<Book> GetBooks(string title, string author, string isbn);
    }
}
