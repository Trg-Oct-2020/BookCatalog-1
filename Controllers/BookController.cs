using BookCatalog.MicroService.Helpers;
using BookCatalog.MicroService.Models;
using BookCatalog.MicroService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

            // GET api/values
            private ILogger _logger;
            private IBookService _service;


            public BookController(ILogger<BookController> logger, IBookService service)
            {
                _logger = logger;
                _service = service;

            }

            [HttpGet("/api/book/getBookList")]
            public ActionResult<List<BookDTO>> GetBook()
                {
                    return _service.GetBook().ToList();
                }


        [HttpGet("/api/book/getBooks")]
        public ActionResult<List<BookDTO>> GetBook([FromQuery] BookParams bookParams)
        {
            return _service.GetBooks(bookParams.title, bookParams.author, bookParams.isbn).ToList();
        }

       
        [HttpPost("/api/book/InsertBook")]
            public ActionResult<List<BookDTO>> AddBook(BookDTO bookdto)
                {
                    return _service.AddBook(bookdto).ToList();
                }

            [HttpPut("/api/Book/UpdateBook")]
            public ActionResult<List<BookDTO>> UpdateBook(BookDTO bookdto)
            {
                return _service.UpdateBook(bookdto).ToList();
        }

       
            [HttpDelete("/api/book/delete/{id}")]
            public ActionResult<string> DeleteBook(string id)
            {
                _service.DeleteBook(id);
                 return id;
            }
    }
    

}
