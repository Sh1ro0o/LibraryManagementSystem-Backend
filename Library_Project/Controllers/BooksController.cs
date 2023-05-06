using AutoMapper;
using Library_Project.Dto;
using Library_Project.Interfaces;
using Library_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
        }


        [HttpGet("id/{bookId}")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookService.BookExists(bookId))
                return NotFound();

            var book = _bookService.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooks()
        {
            List<BookDto> books = _bookService.GetBooks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }
    }
}
