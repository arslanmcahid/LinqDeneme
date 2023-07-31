using Core.Models;

namespace Core.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetBookWithCategoryAndTitle();
        List<Book> GroupedBookForAuthor();
        List<Book> FilteredBooksForCategory(int categoryId);
        List<Book> BooksThatCategoryNameIncluded(string harf);
        List<Book> Listed10BooksForTitleAndCategoryName();

    }
}
