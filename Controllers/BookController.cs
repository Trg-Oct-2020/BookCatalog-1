using BookCatalog.MicroService.Helpers;
using BookCatalog.MicroService.Models;
using BookCatalog.MicroService.Services;
using Microsoft.AspNetCore.Http;
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

       
        private ILogger _logger;
        private IBookService _service;


        public BookController(ILogger<BookController> logger, IBookService service)
        {
            _logger = logger;
            _service = service;

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/book/list")]
        public ActionResult<List<BookDTO>> GetAll()
        {
            try
            {
                return _service.Book.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/book/search")]
        public ActionResult<List<BookDTO>> GetBook([FromQuery] BookParams bookParams)
        {
            try
            {
                return _service.GetBooks(bookParams.title, bookParams.author, bookParams.isbn).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("/api/book/add")]
        public ActionResult<List<BookDTO>> AddBook(BookDTO bookdto)
        {
            try
            {
                return _service.AddBook(bookdto).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("/api/book/update")]
        public ActionResult<List<BookDTO>> UpdateBook(BookDTO bookdto)
        {

            try
            {
                return _service.UpdateBook(bookdto).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("/api/book/delete/{id}")]
        public ActionResult<string> DeleteBook(string id)
        {
            try
            {
                _service.DeleteBook(id);
                return id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}
