using BookCatalog.MicroService.DTOs;
using System.Collections.Generic;


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
