using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System.Linq.Expressions;

namespace Service.Services
{
    public class BookReaderService : IBookReaderService
    {
        private readonly IBookReaderService _bookReaderService;
        private readonly IUnitOfWork _unitOfWork;

        public BookReaderService(IBookReaderService bookReaderService, IUnitOfWork unitOfWork)
        {
            _bookReaderService = bookReaderService;
            _unitOfWork = unitOfWork;
        }

        public Task<BookReader> AddAsync(BookReader entity)
        {
            return _bookReaderService.AddAsync(entity);
        }

        public Task<IEnumerable<BookReader>> AddRangeAsync(IEnumerable<BookReader> entities)
        {
            return _bookReaderService.AddRangeAsync(entities);
        }

        public Task<bool> AnyAsync(Expression<Func<BookReader, bool>> expression)
        {
            return _bookReaderService.AnyAsync(expression);
        }

        public Task<IEnumerable<BookReader>> GetAllAsync()
        {
            return _bookReaderService.GetAllAsync();
        }

        public Task<CustomResponseDto<BookReaderDto>> GetAllReverseForId()
        {
            return _bookReaderService.GetAllReverseForId();
        }

        public Task<BookReader> GetByIdAsync(int id)
        {
            return _bookReaderService.GetByIdAsync(id);
        }

        public Task<CustomResponseDto<BookReaderDto>> GetSameEmail()
        {
            return _bookReaderService.GetSameEmail();
        }

        public Task RemoveAsync(BookReader entity)
        {
            return _bookReaderService.RemoveAsync(entity);
        }

        public Task RemoveRangeAsync(IEnumerable<BookReader> entities)
        {
            return _bookReaderService.RemoveRangeAsync(entities);
        }

        public Task UpdateAsync(BookReader entity)
        {
            return _bookReaderService.UpdateAsync(entity);
        }

        public IQueryable<BookReader> Where(Expression<Func<BookReader, bool>> expression)
        {
            return _bookReaderService.Where(expression);
        }
    }
}