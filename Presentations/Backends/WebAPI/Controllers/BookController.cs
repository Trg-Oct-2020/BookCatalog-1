using BookCatalog.Application.DTOs;
using BookCatalog.Application.Services;
using BookCatalog.MicroService.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookCatalog.Presentations.Backends.WebAPI.Controllers
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

        public async Task<IActionResult> GetAll()
        {

            return Ok(await _service.GetAll());

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/book/search")]
        public async Task<IActionResult> GetBookAsync([FromQuery] BookParams bookParams)
        {
            try
            {
                return Ok(await _service.GetBooks(bookParams.title, bookParams.author, bookParams.isbn));
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


        public async Task<IActionResult> AddAsync(BookDTO bookdto)
        {
            var result = await _service.Add(bookdto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("/api/book/update")]


        public async Task<IActionResult> Update(BookDTO bookdto)
        {
            var result = await _service.Update(bookdto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("/api/book/delete/{id}")]


        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("Attempting to delete the book with {id}!", id);
            var result = await _service.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation("Searching for the book with id {id}!", id);
            var Book = await _service.GetById(id);
            if (Book == null)
            {
                return BadRequest($"No data available for id {id}");
            }
            return Ok(Book);
        }

    }
}
