using Core.Models;

namespace Core.Repositories
{
    public interface IBookReaderRepository : IGenericRepository<BookReader>
    {
        List<BookReader> GetAllReverseForId();
        List<BookReader> GetSameEmail();

    }
}
