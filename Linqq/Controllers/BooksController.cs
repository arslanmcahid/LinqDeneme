using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Linqq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new {id = book.Id},bookDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            var book = _mapper.Map<Book>(bookDto);
            book.Id = id;
            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(book);
            return NoContent();
        }
    }
}