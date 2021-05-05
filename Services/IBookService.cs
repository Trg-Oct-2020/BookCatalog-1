using BookCatalog.MicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookCatalog.MicroService.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> Book { get; }

        IEnumerable<BookDTO> AddBook(BookDTO bookdto);
        IEnumerable<BookDTO> UpdateBook(BookDTO bookdto);
        string DeleteBook(string id);
        IEnumerable<BookDTO> GetBooks(string title, string author, string isbn);
    }
}
