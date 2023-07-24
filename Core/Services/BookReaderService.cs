using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Services
{
    public class BookReaderService
    {
        private readonly IRepository<BookReader> _repo;
        public BookReaderService(IRepository<BookReader> repo)
        {
            _repo = repo;
        }
        public IEnumerable<BookReader> GetAllReaders()
        {
            return _repo.GetAll();
        }
        public BookReader GetReaderById(int id)
        {
            return _repo.GetById(id);
        }
        public void AddReader(BookReader reader)
        {
            _repo.Add(reader);
        }
        public void UpdateReader(BookReader reader)
        {
            _repo.Update(reader);
        }
        public void DeleteReader(BookReader reader)
        {
            _repo.Delete(reader);
        }
    }
}