using Core.Models;
using Core.Repositories;
namespace Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public List<Book> BooksThatCategoryNameIncluded(string harf)
        {
            return _context.Books.Where(x => x.Category.Name.Contains(harf)).ToList();
            
        }

        public List<Book> FilteredBooksForCategory(int categoryId)
        {
            return _context.Books.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Task<List<Book>> GetBookWithCategoryAndTitle()
        {
            //var books = _context.Books.Select(x => new { x.Title, x.Category.Name });
            return (Task<List<Book>>)_context.Books.Select(x => new { x.Title, x.Category.Name });
        }

        public List<Book> GroupedBookForAuthor()
        {
            return (List<Book>)_context.Books.GroupBy(x => x.Author).Where(x => x.Count() > 1).SelectMany(x => x);
        }

        public List<Book> Listed10BooksForTitleAndCategoryName()
        {
            return (List<Book>)_context.Books.Select(x => new { x.Title, x.Category.Name }).Take(10);
        }
    }
}
