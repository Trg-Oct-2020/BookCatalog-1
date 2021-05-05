using AutoMapper;
using BookCatalog.MicroService.Models;
using BookCatalog.MicroService.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace BookCatalog.MicroService.Services
{
    public class BookService:IBookService
    {
        private IBookRepository _bookrepository;
        private List<Book> _bookDetails;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookrepository, IMapper mapper)
        {
            _bookDetails = new List<Book>();
            _bookrepository = bookrepository;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> GetBook()
        {
           return _bookrepository.GetBook().ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<BookDTO> AddBook(BookDTO bookdto)
        {
            
            return _bookrepository.AddBook(_mapper.Map<Book>(bookdto)).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<BookDTO> UpdateBook( BookDTO bookdto)
        {
            
            return _bookrepository.UpdateBook(_mapper.Map<Book>(bookdto)).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

        public string DeleteBook(string id)
        {
             return _bookrepository.DeleteBook(id);            
        }


        public IEnumerable<BookDTO> GetBooks(string title, string author, string isbn)
        {

            return _bookrepository.GetBooks(title,author,isbn).ProjectTo<BookDTO>(_mapper.ConfigurationProvider);
        }

        public void SendMessagetoQueue(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
                //var message = "Book:Added";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
