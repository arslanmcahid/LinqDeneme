using Core.DTOs;
using Core.Models;
using System.Runtime.CompilerServices;

namespace Core.Services
{
    public interface IBookService:IService<Book>
    {
        Task<CustomResponseDto<List<BookDto>>> GetBookWithCategoryAndTitle();
        Task<CustomResponseDto<List<BookDto>>> GroupedBookForAuthor();
        Task<CustomResponseDto<List<BookDto>>> FilteredBooksForCategory(int categoryId);
        Task<CustomResponseDto<List<BookDto>>> BooksThatCategoryNameIncluded(string harf);
        Task<CustomResponseDto<List<BookDto>>> Listed10BooksForTitleAndCategoryName();
    }
}