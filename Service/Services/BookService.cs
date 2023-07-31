using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
namespace Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly IBookService _bookService;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IGenericRepository<Book> repository, IUnitOfWork unitOfWork, IBookService serv) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookService = serv;
        }

        public Task<CustomResponseDto<List<BookDto>>> BooksThatCategoryNameIncluded(string harf)
        {
            return _bookService.BooksThatCategoryNameIncluded(harf);
        }

        public Task<CustomResponseDto<List<BookDto>>> FilteredBooksForCategory(int categoryId)
        {
            return _bookService.FilteredBooksForCategory(categoryId);
        }

        public Task<CustomResponseDto<List<BookDto>>> GetBookWithCategoryAndTitle()
        {
            return _bookService.GetBookWithCategoryAndTitle();
        }

        public Task<CustomResponseDto<List<BookDto>>> GroupedBookForAuthor()
        {
            return _bookService.GroupedBookForAuthor();
        }

        public Task<CustomResponseDto<List<BookDto>>> Listed10BooksForTitleAndCategoryName()
        {
            return _bookService.Listed10BooksForTitleAndCategoryName();
        }
    }
}