using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IEnumerable<Book> GetAllBooks() 
        {
            return _bookRepository.GetAll();
        }
        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }
        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }
        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }
        public void DeleteBook(Book book) 
        {
            _bookRepository.Delete(book);
        }
    }
}
