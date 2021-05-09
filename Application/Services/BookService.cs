using AutoMapper;
using BookCatalog.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BookCatalog.MicroService.Messaging.Send.Sender;
using BookCatalog.Domain.Entities;
using BookCatalog.Infra.Persistence.Repositories;
using BookCatalog.MicroService.Application.Utilities.Results;
using System;
using System.Threading.Tasks;

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

 

        public async Task<List<BookDTO>> GetAll()
        {
            return (await _bookrepository.GetAll()).ProjectTo<BookDTO>(_mapper.ConfigurationProvider).ToList();
        }
        public async Task<IResult> Add(BookDTO bookdto)
        {
          
            
                   

                if (await _bookrepository.AddAsync(_mapper.Map<Book>(bookdto))    )
                { 
                    _bookSender.SendMessagetoQueue("Book Added");
                    return new SuccessResult("Book Added");
                }
                else
                {
                    _bookSender.SendMessagetoQueue("Book could not be added");
                    return new ErrorResult("Book could not be added");
                }
           
        }
        public async Task<IResult> Update(BookDTO bookdto)
        {
            if (await _bookrepository.UpdateAsync(_mapper.Map<Book>(bookdto)))
            {
              
                _bookSender.SendMessagetoQueue("Book Updated");
                return new SuccessResult("Book Updated");
            }
            else
            {
                return new ErrorResult("Book could not be updated");
            }
              
        }      

        public async Task<IResult> Delete(string id)
        {            
            if (GetById(id)==null)
                return new ErrorResult("Book could not be found for id : "+id);

            if (await _bookrepository.DeleteAsync(id))
            {
               
                _bookSender.SendMessagetoQueue("Book Deleted");
                return new SuccessResult("Book Deleted");
            }
            else
            {
                return new ErrorResult("Book could not be deleted");
            }
        }

        public async Task<IEnumerable<BookDTO>> GetBooks(string title, string author, string isbn)
        {
            return  (await _bookrepository.Get(title, author, isbn)).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<BookDTO> GetById(string id)
        {
            return _mapper.Map<BookDTO>(await _bookrepository.GetById(id));
        }
    }
}
