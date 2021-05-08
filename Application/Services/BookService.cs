using AutoMapper;
using BookCatalog.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BookCatalog.MicroService.Messaging.Send.Sender;
using BookCatalog.Domain.Entities;
using BookCatalog.Infra.Persistence.Repositories;

namespace BookCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookrepository;
        private List<Book> _bookDetails;
        private readonly IMapper _mapper;
        private IBookSender _bookSender;
        public BookService(IBookRepository bookrepository, IMapper mapper, IBookSender bookSender)
        {
            _bookDetails = new List<Book>();
            _bookrepository = bookrepository;
            _mapper = mapper;
            _bookSender = bookSender;
        }

        public IEnumerable<BookDTO> Book => _bookrepository.GetAll().ProjectTo<BookDTO>(_mapper.ConfigurationProvider);

        public IEnumerable<BookDTO> AddBook(BookDTO bookdto)
        {

            var result = _bookrepository.Add(_mapper.Map<Book>(bookdto)).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
            if (result.Any())
            {
                _bookSender.SendMessagetoQueue("Book Added");
            }
            return result;
        }

        public IEnumerable<BookDTO> UpdateBook(BookDTO bookdto)
        {
            var result = _bookrepository.Update(_mapper.Map<Book>(bookdto)).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
            if (result.Any())
            {
                _bookSender.SendMessagetoQueue("Book Updated");
            }
            return result;
        }

        public string DeleteBook(string id)
        {
            var result = _bookrepository.Delete(id);
            if (!string.IsNullOrEmpty(result))
            {
                _bookSender.SendMessagetoQueue("Book Deleted");
            }
            return result;
        }


        public IEnumerable<BookDTO> GetBooks(string title, string author, string isbn)
        {
            return _bookrepository.Get(title, author, isbn).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

    }

}
