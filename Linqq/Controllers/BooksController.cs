using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
namespace Linqq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Book> _service;
        private readonly IBookService _bookService;
        public BooksController(IMapper mapper, IService<Book> service, IBookService bookService)
        {
            _mapper = mapper;
            _service = service;
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _service.GetAllAsync();
            var booksDto = _mapper.Map<List<BookDto>>(books.ToList());
            return CreateActionResult(CustomResponseDto<List<BookDto>>.Success(204, booksDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return CreateActionResult(CustomResponseDto<BookDto>.Success(200, bookDto));
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            var book = await _service.AddAsync(_mapper.Map<Book>(bookDto));
            var booksDto = _mapper.Map<BookDto>(book);
            return CreateActionResult(CustomResponseDto<BookDto>.Success(200, booksDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookDto bookDto)
        {
            await _service.UpdateAsync(_mapper.Map<Book>(bookDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var book = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(book);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        #region Yazara gore gruplama
        [HttpGet("GroupByAuthor/")]
        public async Task<IActionResult> GroupByAuthor()
        {
            var book = await _bookService.GroupedBookForAuthor();
            var bookDto = _mapper.Map<BookDto>(book);
            return CreateActionResult(CustomResponseDto<BookDto>.Success(200, bookDto));
            //var book = _service.GetAllAsync();
            //var booka = _bookService.GetAllBooks().GroupBy(x=>x.Author).Where(group => group.Count() > 1).SelectMany(group => group);
            //var bookDto = _mapper.Map<List<BookDto>>(book);
            //return Ok(bookDto);
        }
        #endregion
        #region Kategorisi 5 olan kitaplar
        [HttpGet("categoryof/{id}")]
        public async Task<IActionResult> GetByBooksofCategory(int categoryId)
        {
            var books = await _bookService.FilteredBooksForCategory(categoryId);
            var booksDto = _mapper.Map<BookDto>(books);
            return CreateActionResult(CustomResponseDto<BookDto>.Success(200, booksDto));
            //var books = _bookService.GetAllBooks().Where(x=>x.CategoryId == 5);
            //var booksDto = _mapper.Map<List<BookDto>>(books);
            //return Ok(booksDto);
        }
        #endregion
        #region title and categoryname listeleme
        [HttpGet("ListforTitleAndCategory")]
        public async Task<IActionResult> GetListForTitleAndCategory()
        {
            var books = await _bookService.GetBookWithCategoryAndTitle();
            var booksDto = _mapper.Map<BookDto>(books);
            return CreateActionResult(CustomResponseDto<BookDto>.Success(200, booksDto));
        }
        #endregion  
    }
}