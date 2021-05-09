using BookCatalog.Application.DTOs;
using BookCatalog.MicroService.Application.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.Application.Services
{
    public interface IBookService
    {



        Task<IEnumerable<BookDTO>> GetBooks(string title, string author, string isbn);
        Task<BookDTO> GetById(string id);

        Task<List<BookDTO>> GetAll();

        Task<IResult> Add(BookDTO bookdto);
        Task<IResult> Update(BookDTO bookdto);
        Task<IResult> Delete(string id);


    }
}
