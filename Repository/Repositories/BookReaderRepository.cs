using Core.Models;
using Core.Repositories;

namespace Repository.Repositories
{
    public class BookReaderRepository : GenericRepository<BookReader>, IBookReaderRepository
    {
        public BookReaderRepository(AppDbContext context) : base(context)
        {
        }

        public List<BookReader> GetAllReverseForId()
        {
            return _context.Readers.OrderByDescending(x => x.Id).ToList();
        }

        public List<BookReader> GetSameEmail()
        {
            return _context.Readers.GroupBy(x=>x.Email).Where(group => group.Count() > 1).SelectMany(group=>group).ToList();
        }
    }
}
